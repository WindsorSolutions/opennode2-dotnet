package com.windsor.node.domain.entity;

import java.io.Serializable;

/**
 * Provides an object encapsulating uploaded plugin data.
 */
public class PluginUpload implements Serializable {

    private String filename;

    private String contentType;

    private byte[] bytes;

    private Long size;

    public String getFilename() {
        return filename;
    }

    public void setFilename(String filename) {
        this.filename = filename;
    }

    public String getContentType() {
        return contentType;
    }

    public void setContentType(String contentType) {
        this.contentType = contentType;
    }

    public byte[] getBytes() {
        return bytes;
    }

    public void setBytes(byte[] bytes) {
        this.bytes = bytes;
    }

    public Long getSize() {
        return size;
    }

    public void setSize(Long size) {
        this.size = size;
    }
}
