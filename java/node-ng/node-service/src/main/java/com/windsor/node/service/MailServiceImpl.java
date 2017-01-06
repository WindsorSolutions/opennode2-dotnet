package com.windsor.node.service;

import java.io.IOException;
import java.io.StringWriter;
import java.util.Map;

import javax.mail.MessagingException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMessage.RecipientType;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;

import com.windsor.node.domain.MailTemplate;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.props.NosProperties;

import freemarker.template.Configuration;
import freemarker.template.Template;
import freemarker.template.TemplateException;

@Service
public class MailServiceImpl implements MailService {

	@Autowired
	private Configuration configuration;
	
    @Autowired
    private JavaMailSender mailSender;
    
    @Autowired
    private NosProperties nosProperties;
	
	@Override
	public void send(Account account, MailTemplate template, Map<String, String> properties) {
		try {
			StringWriter writer = new StringWriter();
			Template t = configuration.getTemplate(template.getBodyTemplateName());
			t.process(properties, writer);
			String out = writer.toString();
			MimeMessage msg = mailSender.createMimeMessage();
			msg.setText(out);
			msg.setSubject(template.getSubject());
			msg.setFrom(new InternetAddress(nosProperties.getFromEmailAddress()));
			msg.setRecipient(RecipientType.TO, new InternetAddress(account.getNaasAccount()));
			mailSender.send(msg);
		} catch (IOException | TemplateException | MessagingException e) {
			throw new RuntimeException("Error sending mail: account=" + account.getNaasAccount() + ", template=" + template, e);
		}
	}

}
