package com.windsor.node.plugin.common.file;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

abstract class AbstractFileCreator implements FileCreator {

    private static final String DEFAULT_EXTENSION = "";

    private static final Logger LOG = LoggerFactory.getLogger(AbstractFileCreator.class);

    protected abstract String getFileName();

    protected abstract String getDirectoryAbsolutePath();

    protected abstract String getExtension();

    @Override
    public File createFile() throws IOException {
        return getFile();
    }

    private File getFile() throws IOException {
        FileUtils.forceMkdir(new File(directoryAbsolutePath()));
        return new File(documentAbsolutePath());
    }

    private String documentAbsolutePath() {
        return directoryAbsolutePath() + File.separator + fileName() + extension();
    }

    private String fileName() {
        String f = getFileName();
        return (StringUtils.isNotEmpty(f) ? f : "");
    }

    private String directoryAbsolutePath() {
        String d = getDirectoryAbsolutePath();
        return (StringUtils.isNotEmpty(d) ? d : "");
    }

    private String extension() {
        String ext = getExtension();
        return (StringUtils.isNotEmpty(ext) ? "." + ext : DEFAULT_EXTENSION);
    }

    private void error(Throwable t) {
        LOG.error("", t);
    }
}
