package com.windsor.node.plugin.uic2;

import com.windsor.node.plugin.uic2.domain.UICDataType;

public interface UicDao {

    UICDataType findByOrgId(String orgId);

}
