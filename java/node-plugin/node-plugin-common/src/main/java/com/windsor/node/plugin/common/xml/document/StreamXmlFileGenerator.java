package com.windsor.node.plugin.common.xml.document;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import com.windsor.node.plugin.common.file.FileCreator;
import com.windsor.node.plugin.common.xml.stream.ElementWriter;

public class StreamXmlFileGenerator<T> implements DocumentGenerator {

    private final FileCreator fileCreator;

    private final ElementsDataProvider<T> dataProvider;

    private final ElementWriter writer;

    private final ElementWriteHandler<T> writeHandler;

    public StreamXmlFileGenerator(FileCreator fileCreator,
            ElementsDataProvider<T> dataProvider,
            ElementWriteHandler<T> writeHandler,
            ElementWriter writer) {

        this.fileCreator = fileCreator;
        this.dataProvider = dataProvider;
        this.writeHandler = writeHandler;
        this.writer = writer;
    }

    @Override
    public File generate() throws IOException {

        File file = fileCreator.createFile();

        FileOutputStream fos = null;

        try {

            fos = new FileOutputStream(file);

            writer.open(fos);

            Iterable<T> it = this.dataProvider.elements();

            for(T t : it) {
                writeHandler.handle(writer, t);
            }

        } catch (Exception e) {
            throw new IOException(e.getLocalizedMessage(), e);
        } finally {
            if (writer != null) {
                writer.close();
            }
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    throw e;
                }
            }
        }
        return file;
    }
}