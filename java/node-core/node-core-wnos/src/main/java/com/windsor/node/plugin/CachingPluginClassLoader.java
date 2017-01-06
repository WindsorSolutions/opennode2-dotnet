/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.plugin;

import java.io.File;
import java.io.FilenameFilter;
import java.io.IOException;
import java.lang.reflect.Modifier;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;
import java.util.zip.ZipEntry;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.PluginMetaDataFactory;
import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.data.dao.SelfDescribingPluginServiceImplementor;

public class CachingPluginClassLoader implements WnosClassLoader
{

    // NOTE: Do not make this static, want to make sure this class is unloaded
    // as soon as possible
    private Logger logger = LoggerFactory.getLogger(CachingPluginClassLoader.class);
    private Class<BaseWnosPlugin> pluginTemplate = BaseWnosPlugin.class;
    private Map<String, ClassLoader> cachedClassLoaders;

    public CachingPluginClassLoader()
    {
        this.cachedClassLoaders = new TreeMap<String, ClassLoader>();
    }

    public Object getPluginInstance(File rootDir, String fullyQualifiedClassName)
    {
        try
        {
            logger.debug("PluginClassLoader: (rootDir=" + rootDir + ")");

            if(rootDir == null || !rootDir.exists())
            {
                throw new IllegalArgumentException("rootDir not set or does not exist: " + rootDir);
            }

            logger.debug("getting instance from: " + fullyQualifiedClassName);
            Object testObj = getClassInstance(rootDir, fullyQualifiedClassName);

            logger.debug("instance: " + testObj);

            if(testObj == null)
            {
                throw new RuntimeException("Unable to find: " + fullyQualifiedClassName);
            }

            if(pluginTemplate.isAssignableFrom(testObj.getClass()))
            {
                return testObj;
            }
            else
            {
                throw new RuntimeException("Plugin not assignable from: " + testObj);
            }
        }
        catch(Exception ex)
        {
            throw new RuntimeException("Error while instantiating (Exception): " + fullyQualifiedClassName, ex);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.WnosClassLoader#getBasePluginImplementors(java
     * .io.File)
     */
    public List<String> getBasePluginImplementors(File rootDir)
    {

        List<String> resultList = new ArrayList<String>();

        try
        {
            logger.debug("PluginClassLoader: (rootDir=" + rootDir + ")");

            if(rootDir == null || !rootDir.exists())
            {
                throw new IllegalArgumentException("rootDir not set or does not exist: " + rootDir);
            }

            // get jars for that flow
            String[] files = rootDir.list(new JarFilter());

            for (int f = 0; f < files.length; f++)
            {
                logger.debug("Jar file name: " + files[f]);
                String fullJarPath = FilenameUtils.concat(rootDir.getAbsolutePath(), files[f]);
                logger.debug("Jar file path: " + fullJarPath);
                resultList.addAll(loadImplementersFromJar(fullJarPath));
            }

        }
        catch(Exception ex)
        {
            logger.error(ex.getMessage(), ex);
        }

        return resultList;
    }

    private Object getClassInstance(File rootDir, String fullyQualifiedClassName) throws ClassNotFoundException
    {
        // get jars for that flow
        String[] files = rootDir.list(new JarFilter());

        for (int f = 0; f < files.length; f++)
        {
            logger.debug("Jar file name: " + files[f]);
            String fullJarPath = FilenameUtils.concat(rootDir.getAbsolutePath(), files[f]);
            logger.debug("Jar file path: " + fullJarPath);
            Object testObject = getClassInstanceFromJar(fullJarPath, fullyQualifiedClassName);
            if(testObject != null)
            {
                return testObject;
            }
        }

        throw new ClassNotFoundException(fullyQualifiedClassName);
    }

    private List<String> loadImplementersFromJar(String jarFilePath)
    {
        List<String> matches = new ArrayList<String>();
        URLClassLoader ucl = null;
        try
        {
            // List all the types in the jar file that is passed in as a
            // parameter
            URL[] urls = new URL[1];
            Enumeration<? extends ZipEntry> e = null;
            java.util.zip.ZipFile zf = null;

            // quick fix that avoids issues with illegal characters,
            // java.io.File class' toURL() was deprecated anyway
            urls[0] = new File(jarFilePath).toURI().toURL();
            zf = new java.util.zip.ZipFile(jarFilePath);
            e = zf.entries();

            if(this.cachedClassLoaders.get(jarFilePath) != null)
            {
                ucl = (URLClassLoader)this.cachedClassLoaders.get(jarFilePath);
            }
            else
            {
                ucl = new URLClassLoader(urls, BaseWnosPlugin.class.getClassLoader());

                //jarFilePath contains a unique path to an uploaded plugin, if it's been re-uploaded, reload it anyway,
                //just use the cached version instead of a new classloader, to prevent them from leaking (which they
                //will do regardless, so just take advantage of the leaky behavior) 
                this.cachedClassLoaders.put(jarFilePath, ucl);
            }

            while (e.hasMoreElements())
            {
                java.util.zip.ZipEntry ze = (java.util.zip.ZipEntry) e.nextElement();
                if(!ze.isDirectory())
                {

                    String className = jarToClassName(ze.getName());
                    logger.debug("Found     : " + className);

                    if(StringUtils.isNotBlank(className))
                    {

                        logger.debug("Loading   : " + className);

                        Class<?> c = ucl.loadClass(className);

                        if(pluginTemplate.isAssignableFrom(c) && !Modifier.isAbstract(c.getModifiers()))
                        {

                            logger.debug("Adding    : " + className);

                            // TODO this is the place to filter out abstract
                            // classes
                            matches.add(className);
                        }

                    }
                }
            }

            if(zf != null)
            {
                zf.close();
            }

        }
        catch(Exception pluginEx)
        {
            logger.error(pluginEx.getMessage(), pluginEx);
        }
        finally
        {
            /*
             * if(ucl != null) { try { ucl.close(); } catch(IOException e) {
             * logger.error(
             * "Unable to close URLClassLoader due to following IOException, this has a high likelihood of creating a memory/classloader leak"
             * , e); } }
             */
        }

        return matches;
    }

    @Override
    public PluginMetaData getPluginMetaData(File pluginVersionDir)
    {
        if(pluginVersionDir == null)
        {
            throw new IllegalArgumentException("Parameter File pluginVersionDir for method getPluginMetaData(...) cannot be null.");
        }
        String[] files = pluginVersionDir.list(new JarFilter());
        String jarName = null;
        PluginMetaData data = null;
        if(files != null && files.length == 1)
        {
            jarName = files[0];
            PluginMetaDataFactory fact = (PluginMetaDataFactory) getClassInstanceFromJar(pluginVersionDir.getAbsolutePath() + File.separator + jarName,
                            "com.windsor.node.plugin.common.PluginMetaDataFactoryImpl");
            if(fact != null)
            {
                data = fact.createPluginMetaData();
            }
        }
        return data;
    }

    @Override
    public List<PluginServiceImplementorDescriptor> getPluginServiceImplementorDescriptors(File pluginVersionDir)
    {
        if(pluginVersionDir == null)
        {
            throw new IllegalArgumentException("Parameter File pluginVersionDir for method getPluginMetaData(...) cannot be null.");
        }
        List<PluginServiceImplementorDescriptor> implementorDescriptors = new ArrayList<PluginServiceImplementorDescriptor>();

        URLClassLoader ucl = null;
        try
        {
            String[] files = pluginVersionDir.list(new JarFilter());
            File jarFile = null;
            if(files != null && files.length == 1)
            {
                jarFile = new File(pluginVersionDir + File.separator + files[0]);
            }
            else
            {
                throw new WinNodeException("Plugin Jar file did not exist in directory:  " + pluginVersionDir.getAbsolutePath());
            }

            URL[] urls = new URL[1];
            Enumeration<? extends ZipEntry> enumerationOfJarClasses = null;
            java.util.zip.ZipFile zf = null;

            urls[0] = jarFile.toURI().toURL();
            zf = new java.util.zip.ZipFile(jarFile);
            enumerationOfJarClasses = zf.entries();

            ucl = new URLClassLoader(urls, BaseWnosPlugin.class.getClassLoader());

            while (enumerationOfJarClasses.hasMoreElements())
            {
                java.util.zip.ZipEntry ze = (java.util.zip.ZipEntry) enumerationOfJarClasses.nextElement();
                if(!ze.isDirectory())
                {
                    String className = jarToClassName(ze.getName());
                    if(StringUtils.isNotBlank(className))
                    {
                        logger.debug("Loading:  " + className);
                        Class<?> c = ucl.loadClass(className);
                        if(SelfDescribingPluginServiceImplementor.class.isAssignableFrom(c) && !Modifier.isAbstract(c.getModifiers()))
                        {
                            logger.debug("Adding:  " + className);
                            PluginServiceImplementorDescriptor implementor =
                                    ((SelfDescribingPluginServiceImplementor) c.newInstance()).getPluginServiceImplementorDescription();
                            PluginServiceImplementorDescriptor implementorDescriptor = new PluginServiceImplementorDescriptor();
                            implementorDescriptor.setClassName(className);
                            implementorDescriptor.setName(implementor.getName());
                            implementorDescriptor.setDescription(implementor.getDescription());
                            logger.info("Implementor: " + implementorDescriptor);
                            logger.info("Corrected classname");
                            implementorDescriptors.add(implementorDescriptor);
                        }

                    }
                }
            }
            if(zf != null)
            {
                zf.close();
            }

        }
        catch(Exception pluginEx)
        {
            logger.error(pluginEx.getMessage(), pluginEx);
        }
        finally
        {
            /*
             * if(ucl != null) { try { ucl.close(); } catch(IOException e) {
             * logger.error(
             * "Unable to close URLClassLoader due to following IOException, this has a high likelihood of creating a memory/classloader leak"
             * , e); } }
             */
        }
        return implementorDescriptors;
    }

    private Object getClassInstanceFromJar(String jarFilePath, String fullyQualifiedClassName)
    {

        URLClassLoader ucl = null;
        java.util.zip.ZipFile zf = null;
        try
        {
            // List all the classes in the jar that is passed in
            URL[] urls = new URL[1];
            Enumeration<? extends ZipEntry> e = null;

            // quick fix that avoids issues with illegal characters,
            // java.io.File class' toURL() was deprecated anyway
            urls[0] = new File(jarFilePath).toURI().toURL();
            zf = new java.util.zip.ZipFile(jarFilePath);
            e = zf.entries();

            if(this.cachedClassLoaders.get(jarFilePath) != null)
            {
                ucl = (URLClassLoader)this.cachedClassLoaders.get(jarFilePath);
            }
            else
            {
                ucl = new URLClassLoader(urls, BaseWnosPlugin.class.getClassLoader());

                //jarFilePath contains a unique path to an uploaded plugin, if it's been re-uploaded, reload it anyway,
                //just use the cached version instead of a new classloader, to prevent them from leaking (which they
                //will do regardless, so just take advantage of the leaky behavior) 
                this.cachedClassLoaders.put(jarFilePath, ucl);
            }

            while (e.hasMoreElements())
            {
                java.util.zip.ZipEntry ze = (java.util.zip.ZipEntry) e.nextElement();
                if(!ze.isDirectory())
                {

                    String className = jarToClassName(ze.getName());

                    logger.debug("Searching:  " + fullyQualifiedClassName);
                    logger.debug("Found:  " + className);

                    if(StringUtils.isNotBlank(className) && fullyQualifiedClassName.equalsIgnoreCase(className))
                    {
                        logger.debug("Class matched request, loading class:  " + className);

                        Class<?> c = ucl.loadClass(className);
                        return c.newInstance();
                    }
                }
            }

        }
        catch(Exception pluginEx)
        {
            logger.error(pluginEx.getMessage(), pluginEx);
        }
        finally
        {
            if(zf != null)
            {
                try
                {
                    zf.close();
                }
                catch(IOException e)
                {
                    logger.error("Unable to close java.util.zip.ZipFile due to following IOException, this has a high likelihood of creating a memory/classloader leak",
                                    e);
                }
            }
            /*
             * if(ucl != null) { try { ucl.close(); } catch(IOException e) {
             * logger.error(
             * "Unable to close URLClassLoader due to following IOException, this has a high likelihood of creating a memory/classloader leak"
             * , e); } }
             */
        }

        return null;

    }

    /*
     * jarToClassName
     */
    private String jarToClassName(String jarEntry)
    {

        int idxClass = jarEntry.indexOf(".class");

        if(idxClass == -1)
        {
            return null;
        }

        return jarEntry.substring(0, idxClass).replace('/', '.').replace('\\', '.');
    }

    /**
     * JarFilter
     * 
     * @author mchmarny
     * 
     */
    private class JarFilter implements FilenameFilter
    {

        public boolean accept(File dir, String name)
        {
            return FilenameUtils.getExtension(name).equalsIgnoreCase("jar");
        }

    }
}
