package com.windsor.node.service;

import java.io.File;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Path;

import org.apache.commons.io.FileUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSort;
import com.windsor.node.repo.PartnerRepository;
import com.windsor.node.service.helper.naas.auth.AuthMethod;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.node.ws1.client.NetworkNode11Client;
import com.windsor.node.ws2.client.NetworkNode21Client;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Partner service.
 */
@Service
@Transactional(readOnly = true)
public class PartnerServiceImpl extends AbstractCrudService<Partner, String, PartnerSearchCriteria, PartnerSort>
        implements PartnerService {

    @Autowired
    private PartnerRepository repository;

    @Autowired
    private NaasProperties naasProperties;

    @Override
    protected ICrudRepository<Partner, String, PartnerSearchCriteria, PartnerSort> getRepo() {
        return repository;
    }

    @Override
    public Partner load(String id) {
        return repository.getOne(id);
    }

    @Override
    public String validatePartner(Partner partner) throws Exception {
        String result = null;

        NAASAccount naasAccount = new NAASAccount();
        naasAccount.setAuthMethod(AuthMethod.password.getValue());
        naasAccount.setUsername(naasProperties.getNaasRuntimeUsername());
        naasAccount.setPassword(naasProperties.getNaasRuntimePassword());

        NodeClientService client = null;
        Path pathTemp = Files.createTempDirectory("partner-test");
        File fileTemp = new File(pathTemp.toFile().getAbsolutePath());
        FileUtils.forceDeleteOnExit(fileTemp);

        switch(partner.getVersion()) {
            case TWO_DOT_ONE:
                client = new NetworkNode21Client();
                break;

            case ONE_DOT_ONE:
                client = new NetworkNode11Client();
                break;

            default:
                throw new RuntimeException("That type of endpoint does not support test pings: "
                        + partner.getVersion());
        }

        client.configure(new URL(partner.getUrl()), "http://www.google.com", naasAccount, fileTemp);
        result = client.nodePing("Ping");

        return result;
    }
}
