package com.windsor.node.plugin.wqx.domain.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;

import com.windsor.node.plugin.wqx.xml.XmlConstants;

@XmlRegistry
public class DeleteComponentIdentifierObjectFactory {

    @XmlElementDecl(namespace = XmlConstants.NS_WQX_DEFAULT, name = "ProjectIdentifier")
    public JAXBElement<String> createProjectIdentifier(String value) {
        return new JAXBElement<String>(new QName("http://www.exchangenetwork.net/schema/wqx/2", "ProjectIdentifier"), String.class, null, value);
    }

    @XmlElementDecl(namespace = XmlConstants.NS_WQX_DEFAULT, name = "MonitoringLocationIdentifier")
    public JAXBElement<String> createMonitoringLocationIdentifier(String value) {
        return new JAXBElement<String>(new QName("http://www.exchangenetwork.net/schema/wqx/2", "MonitoringLocationIdentifier"), String.class, null, value);
    }

    @XmlElementDecl(namespace = XmlConstants.NS_WQX_DEFAULT, name = "ActivityIdentifier")
    public JAXBElement<String> createActivityIdentifier(String value) {
        return new JAXBElement<String>(new QName("http://www.exchangenetwork.net/schema/wqx/2", "ActivityIdentifier"), String.class, null, value);
    }

    @XmlElementDecl(namespace = XmlConstants.NS_WQX_DEFAULT, name = "ActivityGroupIdentifier")
    public JAXBElement<String> createActivityGroupIdentifier(String value) {
        return new JAXBElement<String>(new QName("http://www.exchangenetwork.net/schema/wqx/2", "ActivityGroupIdentifier"), String.class, null, value);
    }

    @XmlElementDecl(namespace = XmlConstants.NS_WQX_DEFAULT, name = "IndexIdentifier")
    public JAXBElement<String> createIndexIdentifier(String value) {
        return new JAXBElement<String>(new QName("http://www.exchangenetwork.net/schema/wqx/2", "IndexIdentifier"), String.class, null, value);
    }
}