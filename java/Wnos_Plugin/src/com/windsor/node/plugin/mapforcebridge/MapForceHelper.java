/*
 * Copyright (c) 2009, Windsor Solutions, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the Windsor Solutions, Inc., the Environmental 
 *       Council of States (ECOS), nor the names of its contributors may be 
 *       used to endorse or promote products derived from this software 
 *       without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY Windsor Solutions, Inc. "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL Windsor Solutions, Inc. or ECOS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

/**
 * 
 */
package com.windsor.node.plugin.mapforcebridge;

import java.io.File;
import java.io.FilenameFilter;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.net.URL;
import java.net.URLClassLoader;
import java.sql.Connection;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipException;
import java.util.zip.ZipFile;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;

import com.altova.TraceProvider;

/**
 * Helper methods for finding the right MapForce-generated mapping class and
 * method to execute the mapping.
 * 
 * <p>
 * Designed with MapForce 2009 in mind.
 * </p>
 * 
 * @since OpenNode2 v1.1.4
 * 
 */
public class MapForceHelper {

    public static final String MAPFORCE_PLUGIN_JAR_NAME = "mapforcebridge.jar";

    private static Logger logger = Logger.getLogger(MapForceHelper.class);

    public MapForceHelper() {

    }

    /**
     * A class is considered valid if it:
     * <ol>
     * <li>extends com.altova.TraceProvider</li>
     * <li>contains a method with the signature
     * <code>public void run(java.sql.Connection, String...)</code></li>
     * </ol>
     * 
     * @param clazz
     * @return
     */
    public Boolean validateMapForceRunner(Class<?> clazz) {

        Boolean valid = false;

        logger.trace("validateMapForceRunner: " + clazz.getName());

        // validate that clazz extends the right type
        if (null != clazz.getSuperclass()
                && clazz.getSuperclass().equals(TraceProvider.class)) {

            // look for run(Connection, String...)
            Method[] methods = clazz.getDeclaredMethods();

            for (Method m : methods) {

                logger.trace("looking at method: " + m.getName());

                if (isPublicVoidRun(m)) {

                    logger.trace("checking params for method: " + m.getName());

                    if (validateParamTypes(m)) {
                        // we're done looking at methods
                        valid = true;
                        break;
                    }
                }
            }
        }

        return valid;
    }

    /**
     * Get the first .jar file name that's not the plugin support file.
     * 
     * @return
     */
    public String getJarFileName(File directoryToSearch) {

        String jarFileName = null;

        FilenameFilter filter = new FilenameFilter() {
            public boolean accept(File dir, String name) {
                return name.endsWith(".jar");
            }
        };

        String[] files = directoryToSearch.list(filter);

        logger.debug("listing jar files in "
                + directoryToSearch.getAbsolutePath());

        for (String fileName : files) {

        }

        for (String fileName : files) {

            logger.trace("examining jar file: " + fileName);

            if (!fileName.equals(MAPFORCE_PLUGIN_JAR_NAME)) {

                logger.debug("Returning jar file: " + fileName);
                jarFileName = fileName;
                break;
            }
        }

        return jarFileName;
    }

    /* thanks in part to PluginClassLoader in Wnos_Logic */
    /**
     * Get the first occurence of a valid MapForce &quot;runner&quot; from the
     * referenced .jar file.
     * 
     * @param jarFilePath
     * @return a valid MapForce &quot;runner&quot;
     */
    public Class<?> getClassFromJar(String jarFilePath) {

        Class<?> runner = null;
        ZipFile zf;
        URL url;
        Enumeration<? extends ZipEntry> enu;
        ZipEntry ze;

        logger.debug("Searching: " + jarFilePath
                + " for a MapForce mapping implementation...");

        try {

            url = new File(jarFilePath).toURL();
            zf = new ZipFile(jarFilePath);
            enu = zf.entries();
            URLClassLoader ucl = new URLClassLoader(new URL[] { url },
                    MapForceHelper.class.getClassLoader());

            while (enu.hasMoreElements()) {

                ze = (java.util.zip.ZipEntry) enu.nextElement();

                logger.trace("Looking at zip entry : " + ze.getName());

                if (!ze.isDirectory() && StringUtils.isNotBlank(ze.getName())) {

                    String className = jarToClassName(ze.getName());

                    if (StringUtils.isNotBlank(className)) {
                        logger.trace("Loading    : " + className);

                        Class<?> clazz = ucl.loadClass(className);

                        if (validateMapForceRunner(clazz)) {

                            logger.debug("Found a valid implementation: "
                                    + className);

                            runner = clazz;
                            break;

                        }
                    }
                }
            }

            if (zf != null) {
                zf.close();
            }

        } catch (ZipException zex) {

            logger.error("Caught ZipException: " + zex.getMessage());
            throw new RuntimeException(zex);

        } catch (IOException ioe) {

            logger.error("Caught IOException: " + ioe.getMessage());
            throw new RuntimeException(ioe);

        } catch (ClassNotFoundException cnfe) {

            logger.error("Caught ClassNotFoundException: " + cnfe.getMessage());
            throw new RuntimeException(cnfe);
        }

        return runner;
    }

    /**
     * Given a Class, get a Method with the signature
     * <code>public void run(java.sql.Connection, String...)</code>.
     * 
     * <p>
     * The first matching method is returned.
     * </p>
     * 
     * @param clazz
     *            the class to examine
     * @return a Method with the desired signature, <code>null</code> if none is
     *         found
     */
    public Method getRunMethod(Class<?> clazz) {

        Method method = null;

        if (validateMapForceRunner(clazz)) {

            // look for run(Connection, String...)
            Method[] methods = clazz.getDeclaredMethods();

            for (Method m : methods) {

                if (isPublicVoidRun(m)) {

                    if (validateParamTypes(m)) {
                        // we're done looking at methods
                        method = m;
                        break;
                    }
                }
            }

        }

        return method;
    }

    /**
     * Given an arbitrary Class, a JDBC <code>Connection</code>, and arguments,
     * check whether the Class is a valid MapForce &quot;runner&quot;, create an
     * instance, get the first valid &quot;run&quot; method, and invoke it with
     * the <code>Connection</code> and args.
     * 
     * @param clazz
     * @param conn
     * @param args
     * @throws InvocationTargetException
     */
    public void invokeRunMethod(Class<?> clazz, Connection conn, Object... args)
            throws InvocationTargetException {

        if (validateMapForceRunner(clazz)) {

            Method method = getRunMethod(clazz);

            if (isPublicVoidRun(method) && validateParamTypes(method)) {

                // the Connection and String args need to go into an Object[]
                List<Object> methodArgs = new ArrayList<Object>();
                methodArgs.add(conn);
                for (Object arg : args) {
                    methodArgs.add(arg);
                }

                try {

                    // we need to call invoke() on an Object, not the Class!
                    Object obj = clazz.newInstance();
                    logger.trace("invoking run method...");
                    method.invoke(obj, methodArgs.toArray());

                } catch (IllegalAccessException iae) {

                    throw new InvocationTargetException(iae,
                            "invokeRunMethod caught an IllegalAccessException.");

                } catch (InstantiationException ie) {

                    throw new InvocationTargetException(ie,
                            "invokeRunMethod caught an InstantiationException.");
                }
            }
        }
    }

    private Boolean isPublicVoidRun(Method m) {

        Boolean b = false;

        if (m.getName().equals("run")
                && m.getReturnType().getName().equals("void")
                && (m.getModifiers() == Modifier.PUBLIC)) {

            b = true;

        }
        return b;
    }

    private Boolean validateParamTypes(Method method) {

        Boolean valid = false;

        logger.trace("validating parameter types for method: "
                + method.getName());

        Class<?>[] paramTypes = method.getParameterTypes();

        logger.trace("ParameterTypes[]: " + Arrays.toString(paramTypes));

        if (paramTypes[0].equals(Connection.class)) {

            for (int i = 1; i < paramTypes.length; i++) {

                if (!paramTypes[i].equals(String.class)) {
                    // we're done
                    break;

                } else if (i == paramTypes.length - 1) {

                    valid = true;
                }
            }
        }
        return valid;
    }

    /* copied verbatim from PluginClassLoader in Wnos_Logic */
    private String jarToClassName(String jarEntry) {

        int idxClass = jarEntry.indexOf(".class");

        if (idxClass == -1) {
            return null;
        }

        return jarEntry.substring(0, idxClass).replace('/', '.').replace('\\',
                '.');
    }
}
