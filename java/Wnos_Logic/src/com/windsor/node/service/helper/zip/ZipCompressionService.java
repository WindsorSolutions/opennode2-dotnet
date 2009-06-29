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

package com.windsor.node.service.helper.zip;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.rmi.RemoteException;
import java.util.Enumeration;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;
import java.util.zip.ZipOutputStream;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.IOUtil;

public class ZipCompressionService implements CompressionService,
        InitializingBean {

    public final Logger logger = Logger.getLogger(this.getClass());

    private File tempDir;

    public void afterPropertiesSet() {

        if (tempDir == null) {
            throw new RuntimeException("Null tempDir");
        }

        if (!tempDir.exists()) {
            throw new RuntimeException("Dir does not exist");
        }

        if (!tempDir.isDirectory()) {
            throw new RuntimeException("Dir path not dir");
        }

        if (!tempDir.canWrite()) {
            throw new RuntimeException("Dir not writable");
        }

    }

    // OLD

    /**
     * zip
     */
    public byte[] zip(byte[] content, String fileName) {

        if (content == null) {
            throw new RuntimeException("contentO Not Set");
        }

        try {

            File tempFile = new File(FilenameUtils.concat(tempDir
                    .getAbsolutePath(), fileName));

            logger.debug("tempFile: " + tempFile);

            FileUtils.writeByteArrayToFile(tempFile, content);

            if (!tempFile.exists()) {
                throw new RuntimeException(
                        "No errors and no file after FileUtils.writeByteArrayToFile");
            }

            String compressedFilePath = zip(tempFile.getAbsolutePath());

            logger.debug("compressedFilePath: " + compressedFilePath);

            return FileUtils.readFileToByteArray(new File(compressedFilePath));

        } catch (IOException ioe) {

            logger.error("Unhandled exception:" + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping file", ioe);
        }
    }

    public void unzip(byte[] content, String targetDirPath) {

        String sourcePath = FilenameUtils.concat(tempDir.getAbsolutePath(),
                IOUtil.cleanForPath(UUIDGenerator.makeId()));

        File sourceDir = new File(sourcePath);

        try {

            FileUtils.writeByteArrayToFile(sourceDir, content);

            unzip(sourceDir.getAbsolutePath(), targetDirPath);

            FileUtils.forceDeleteOnExit(sourceDir);

        } catch (Exception ex) {

            logger.error("Unhandled exception:" + ex.getMessage(), ex);

            throw new RuntimeException("Error while unzipping file: "
                    + targetDirPath + " Message: " + ex.getMessage(), ex);
        }

    }

    /**
     * unzip
     */
    public void unzip(String sourceFilePath, String targetDirPath) {

        Enumeration entries = null;
        ZipFile zipFile = null;

        try {

            zipFile = new ZipFile(getExistentFile(sourceFilePath));
            entries = zipFile.entries();

            while (entries.hasMoreElements()) {

                ZipEntry entry = (ZipEntry) entries.nextElement();

                if (entry.isDirectory()) {
                    // Assume directories are stored parents first then
                    // children.
                    logger.debug("Extracting directory: " + entry.getName());
                    // This is not robust, just for demonstration purposes.
                    (new File(entry.getName())).mkdir();
                    continue;
                }

                String targetPath = FilenameUtils.concat(targetDirPath, IOUtil
                        .cleanForPath(entry.getName()));

                logger.debug("Extracting file: " + entry.getName() + " to: "
                        + targetPath);

                copyInputStream(zipFile.getInputStream(entry),
                        new BufferedOutputStream(new FileOutputStream(
                                targetPath)));
            }

            zipFile.close();

        } catch (IOException ioe) {

            logger.error("Unhandled exception:");
            logger.error(ioe);

            throw new RuntimeException("Error while unzipping file: "
                    + sourceFilePath, ioe);
        }

    }

    /**
     * zip
     */
    public void zip(String targetFilePath, String sourceDirPath) {

        byte[] buf = new byte[1024];

        try {

            File sourceDir = IOUtil.getExistentFile(sourceDirPath);

            if (!sourceDir.exists() || !sourceDir.isDirectory()) {
                throw new RemoteException("Invalid sourceDirPath: "
                        + sourceDirPath);
            }

            ZipOutputStream out = new ZipOutputStream(new FileOutputStream(
                    targetFilePath));

            // Compress the files
            File[] files = sourceDir.listFiles();
            logger.debug("Found: " + files.length + " files");

            for (int i = 0; i < files.length; i++) {

                FileInputStream in = new FileInputStream(files[i]);

                // Add ZIP entry to output stream.
                out.putNextEntry(new ZipEntry(files[i].getName()));

                // Transfer bytes from the file to the ZIP file
                int len;
                while ((len = in.read(buf)) > 0) {
                    out.write(buf, 0, len);
                }

                // Complete the entry
                out.closeEntry();
                in.close();
            }

            // Complete the ZIP file
            out.close();

        } catch (IOException ioe) {

            logger.error("Unhandled exception:" + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping files from: "
                    + sourceDirPath, ioe);
        }

    }

    public File zip(File sourceFile) {

        if (sourceFile == null || !sourceFile.exists()) {
            throw new IllegalArgumentException("File does not exist: "
                    + sourceFile);
        }

        if (FilenameUtils.getExtension(sourceFile.getAbsolutePath())
                .equalsIgnoreCase("zip")) {
            return sourceFile;
        }

        byte[] buf = new byte[1024];

        try {

            String resultPath = sourceFile.getAbsolutePath() + ".zip";

            ZipOutputStream out = new ZipOutputStream(new FileOutputStream(
                    resultPath));

            FileInputStream in = new FileInputStream(sourceFile);

            // Add ZIP entry to output stream.
            out.putNextEntry(new ZipEntry(sourceFile.getName()));

            // Transfer bytes from the file to the ZIP file
            int len;
            while ((len = in.read(buf)) > 0) {
                out.write(buf, 0, len);
            }

            // Complete the entry
            out.closeEntry();

            in.close();

            // Complete the ZIP file
            out.close();

            return new File(resultPath);

        } catch (Exception ioe) {

            logger.error("Error while zipping file: " + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping file: "
                    + sourceFile, ioe);
        }

    }

    /**
     * zip
     */
    public String zip(String sourceFilePath) {

        byte[] buf = new byte[1024];

        try {

            File sourceFile = IOUtil.getExistentFile(sourceFilePath);

            String resultPath = sourceFilePath + ".zip";

            ZipOutputStream out = new ZipOutputStream(new FileOutputStream(
                    resultPath));

            FileInputStream in = new FileInputStream(sourceFile);

            // Add ZIP entry to output stream.
            out.putNextEntry(new ZipEntry(sourceFile.getName()));

            // Transfer bytes from the file to the ZIP file
            int len;
            while ((len = in.read(buf)) > 0) {
                out.write(buf, 0, len);
            }

            // Complete the entry
            out.closeEntry();
            in.close();

            // Complete the ZIP file
            out.close();

            return resultPath;

        } catch (IOException ioe) {

            logger.error("Unhandled exception:" + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping file: "
                    + sourceFilePath, ioe);
        }

    }

    /**
     * getExistentFile
     * 
     * @param path
     * @return
     * @throws RuntimeException
     */
    private File getExistentFile(String path) throws RuntimeException {

        File testFile = new File(path);

        if (!testFile.exists()) {
            throw new RuntimeException("Unable to find document: "
                    + testFile.getAbsolutePath());
        }

        return testFile;

    }

    /**
     * copyInputStream
     * 
     * @param in
     * @param out
     * @throws IOException
     */
    private static final void copyInputStream(InputStream in, OutputStream out)
            throws IOException {

        byte[] buffer = new byte[1024];
        int len;

        while ((len = in.read(buffer)) >= 0) {
            out.write(buffer, 0, len);
        }

        in.close();
        out.close();
    }

    public void setTempDir(File tempDir) {
        this.tempDir = tempDir;
    }

}