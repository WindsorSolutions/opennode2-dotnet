package com.windsor.node.plugin.uic2;

import com.sun.xml.bind.marshaller.NamespacePrefixMapper;

public class UicNamespaceMapper extends NamespacePrefixMapper {

    @Override
    public String getPreferredPrefix(String namespaceUri, String suggestion, boolean requirePrefix) {
        if ("http://www.exchangenetwork.net/schema/uic/2".equals(namespaceUri)) {
            return "UIC";
        } else {
            return suggestion;
        }
    }

    @Override
    public String[] getPreDeclaredNamespaceUris() {
        return new String[] { "http://www.exchangenetwork.net/schema/uic/2" };
    }

}
