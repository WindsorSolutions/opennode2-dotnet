package com.windsor.node.plugin.wqx.domain;

public class Header {

    private final String documentId;

    private final String author;

    private final String organization;

    private final String title;

    private final String comment;

    private final String contactInfo;

    public Header(String documentId, String operation, String author,
            String organization, String title, String comment,
            String contactInfo) {

        this.documentId = documentId;
        this.author = author;
        this.organization = organization;
        this.title = title;
        this.comment = comment;
        this.contactInfo = contactInfo;
    }

    public String getDocumentId() {
        return documentId;
    }

    public String getAuthor() {
        return author;
    }

    public String getOrganization() {
        return organization;
    }

    public String getTitle() {
        return title;
    }

    public String getComment() {
        return comment;
    }

    public String getContactInfo() {
        return contactInfo;
    }
}