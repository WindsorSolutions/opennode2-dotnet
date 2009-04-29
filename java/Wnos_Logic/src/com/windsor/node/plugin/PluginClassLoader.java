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
import java.net.URL;
import java.net.URLClassLoader;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.util.ClassUtils;

public class PluginClassLoader extends ClassUtils implements WnosClassLoader {

    // NOTE: Do not make this static, want to make sure this class is unloaded
    // as soon
    // as possible
    private Logger logger = Logger.getLogger(PluginClassLoader.class);
    private Class pluginTemplate = BaseWnosPlugin.class;

    public Object getPluginInstance(File rootDir, String fullyQualifiedClassName) {

        try {

            logger.debug("PluginClassLoader: (rootDir=" + rootDir + ")");

            if (rootDir == null || !rootDir.exists()) {
                throw new IllegalArgumentException(
                        "rootDir not set or does not exist: " + rootDir);
            }

            Map exlussionTypes = new HashMap();
            exlussionTypes.put(BaseWnosPlugin.class.getName(),
                    BaseWnosPlugin.class);

            logger.debug("getting instance from: " + fullyQualifiedClassName);
            Object testObj = getClassInstance(rootDir, fullyQualifiedClassName);

            logger.debug("instance: " + testObj);

            if (testObj == null) {
                throw new RuntimeException("Unable to find: "
                        + fullyQualifiedClassName);
            }

            if (isAssignable(pluginTemplate, testObj.getClass())) {

                return testObj;

            } else {
                throw new RuntimeException("Plugin not assignable from: "
                        + testObj);
            }

        } catch (Exception ex) {

            throw new RuntimeException(
                    "Error while instantiating (Exception): "
                            + fullyQualifiedClassName, ex);
        }
    }

    public List getBasePluginImplementors(File rootDir) {

        List resultList = new ArrayList();

        try {

            logger.debug("PluginClassLoader: (rootDir=" + rootDir + ")");

            if (rootDir == null || !rootDir.exists()) {
                throw new IllegalArgumentException(
                        "rootDir not set or does not exist: " + rootDir);
            }

            Map exlussionTypes = new HashMap();
            exlussionTypes.put(BaseWnosPlugin.class.getName(),
                    BaseWnosPlugin.class);

            // get jars for that flow
            String[] files = rootDir.list(new JarFilter());

            for (int f = 0; f < files.length; f++) {

                logger.debug("Jar file name: " + files[f]);

                String fullJarPath = FilenameUtils.concat(rootDir
                        .getAbsolutePath(), files[f]);

                logger.debug("Jar file path: " + fullJarPath);

                loadImplementersFromJar(fullJarPath, resultList);

            }

        } catch (Exception ex) {
            logger.error(ex);
        }

        return resultList;
    }

    private Object getClassInstance(File rootDir, String fullyQualifiedClassName)
            throws ClassNotFoundException {

        // get jars for that flow
        String[] files = rootDir.list(new JarFilter());

        for (int f = 0; f < files.length; f++) {

            logger.debug("Jar file name: " + files[f]);

            String fullJarPath = FilenameUtils.concat(
                    rootDir.getAbsolutePath(), files[f]);

            logger.debug("Jar file path: " + fullJarPath);

            Object testObject = getClassInstanceFromJar(fullJarPath,
                    fullyQualifiedClassName);

            if (testObject != null) {
                return testObject;
            }

        }

        throw new ClassNotFoundException(fullyQualifiedClassName);

    }

    private void loadImplementersFromJar(String jarFilePath, List matches) {

        try {
            // List all the types in the assembly that is passed in as a
            // parameter
            URL[] urls = new URL[1];
            Enumeration e = null;
            java.util.zip.ZipFile zf = null;

            urls[0] = new File(jarFilePath).toURL();
            zf = new java.util.zip.ZipFile(jarFilePath);
            e = zf.entries();

            URLClassLoader ucl = new URLClassLoader(urls, BaseWnosPlugin.class
                    .getClassLoader());

            while (e.hasMoreElements()) {
                java.util.zip.ZipEntry ze = (java.util.zip.ZipEntry) e
                        .nextElement();
                if (!ze.isDirectory()) {

                    String className = jarToClassName(ze.getName());
                    logger.debug("Found     : " + className);

                    if (StringUtils.isNotBlank(className)) {

                        logger.debug("Loading   : " + className);

                        Class c = ucl.loadClass(className);

                        if (isAssignable(pluginTemplate, c)) {

                            if (!matches.contains(className)) {

                                logger.debug("Adding    : " + className);
                                matches.add(className);
                            }

                        }

                    }
                }
            }

            if (zf != null) {
                zf.close();
            }

        } catch (Exception pluginEx) {
            logger.error(pluginEx.getMessage(), pluginEx);
        }
    }

    private Object getClassInstanceFromJar(String jarFilePath,
            String fullyQualifiedClassName) {

        try {
            // List all the types in the assembly that is passed in as a
            // parameter
            URL[] urls = new URL[1];
            Enumeration e = null;
            java.util.zip.ZipFile zf = null;

            urls[0] = new File(jarFilePath).toURL();
            zf = new java.util.zip.ZipFile(jarFilePath);
            e = zf.entries();

            URLClassLoader ucl = new URLClassLoader(urls, BaseWnosPlugin.class
                    .getClassLoader());

            while (e.hasMoreElements()) {
                java.util.zip.ZipEntry ze = (java.util.zip.ZipEntry) e
                        .nextElement();
                if (!ze.isDirectory()) {

                    String className = jarToClassName(ze.getName());

                    logger.debug("Searching: " + fullyQualifiedClassName);
                    logger.debug("Found    : " + className);

                    if (StringUtils.isNotBlank(className)
                            && fullyQualifiedClassName
                                    .equalsIgnoreCase(className)) {

                        logger.debug("Loading    : " + className);

                        Class c = ucl.loadClass(className);
                        return c.newInstance();

                    }
                }
            }

            if (zf != null) {
                zf.close();
            }

        } catch (Exception pluginEx) {
            logger.error(pluginEx.getMessage(), pluginEx);
        }

        return null;

    }

    /*
     * jarToClassName
     */
    private String jarToClassName(String jarEntry) {

        int idxClass = jarEntry.indexOf(".class");

        if (idxClass == -1) {
            return null;
        }

        return jarEntry.substring(0, idxClass).replace('/', '.').replace('\\',
                '.');
    }

    /**
     * JarFilter
     * 
     * @author mchmarny
     * 
     */
    private class JarFilter implements FilenameFilter {

        public boolean accept(File dir, String name) {
            return FilenameUtils.getExtension(name).equalsIgnoreCase("jar");
        }

    }

}