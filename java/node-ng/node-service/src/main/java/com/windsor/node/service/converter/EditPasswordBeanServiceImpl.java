package com.windsor.node.service.converter;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.collect.ImmutableMap;
import com.windsor.node.domain.MailTemplate;
import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.AccountService;
import com.windsor.node.service.MailService;
import com.windsor.node.service.NAASAuthenticationService;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.node.service.props.NosProperties;

@Transactional(readOnly = true)
@Service
public class EditPasswordBeanServiceImpl implements EditPasswordBeanService {

    @Autowired
    private AccountService accountService;

    @Autowired
    private NAASAuthenticationService authenticationService;
    
    @Autowired
    private MailService mailService;
    
    @Autowired
    private NosProperties nosProperties;
    
    @Autowired
    private NaasProperties naasProperties;

    @Transactional(readOnly = false)
    @Override
    public void changePassword(EditPasswordBean bean, Account adminAccount) throws NaasException {
    	String password = bean.getNewPassword();
    	String nodeWebUrl = nosProperties.getExternalAdminUrl();
    	String naasName = naasProperties.getNaasType().getName();
    	if (bean.getId() == null) {
            Account account = accountService.add(bean.getNaasAccount(), password, adminAccount);
            mailService.send(account, MailTemplate.NEW_USER, ImmutableMap.<String, String>builder()
            		.put("type", naasName)
            		.put("username", bean.getNaasAccount())
            		.put("password", password)
            		.put("url", nodeWebUrl)
            		.build());
        } else {
            authenticationService.changePassword(bean.getNaasAccount(), password, adminAccount);
            Account account = accountService.load(bean.getId());
            mailService.send(account, MailTemplate.PASSWORD_CHANGED, ImmutableMap.<String, String>builder()
            		.put("type", naasName)
            		.put("password", password)
            		.put("url", nodeWebUrl)
            		.build());
        }
    }

}
