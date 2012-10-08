package com.windsor.node.plugin.common.file;

public class XmlFileCreator extends AbstractFileCreator {

    private static final String EXT_XML = "xml";

    private final String directoryAbsolutePath;

    private final String fileName;

    public XmlFileCreator(final String directoryAbsolutePath, final String filename) {
        this.directoryAbsolutePath = directoryAbsolutePath;
        this.fileName = filename;
    }

    @Override
    protected final String getExtension() {
        return EXT_XML;
    }

    @Override
    protected String getDirectoryAbsolutePath() {
        return directoryAbsolutePath;
    }

    @Override
    protected String getFileName() {
        return fileName;
    }
}
