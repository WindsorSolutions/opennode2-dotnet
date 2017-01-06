package com.windsor.node.web.component.select2;

import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSorts;
import com.windsor.node.service.AccountService;
import org.apache.wicket.ajax.json.JSONException;
import org.apache.wicket.ajax.json.JSONWriter;
import org.wicketstuff.select2.ChoiceProvider;
import org.wicketstuff.select2.Response;

import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Provides a provider for Account Name instances (i.e. a list of NAAS accounts).
 */
public class AccountNameChoiceProvider extends ChoiceProvider<String> {

    private static final int PAGE_SIZE = 20;

    private AccountService service;

    public AccountNameChoiceProvider(AccountService service) {
        this.service = service;
    }

    @Override
    public void query(String term, int page, Response<String> response) {
        List<String> names = service.find(new AccountSearchCriteria().name(term), AccountSorts.NAME, PAGE_SIZE * page, PAGE_SIZE)
                .map(r -> r.getNaasAccount()).collect(Collectors.toList());
        response.setResults(names);
        response.setHasMore(Boolean.valueOf(names.size() == PAGE_SIZE));
    }

    @Override
    public void toJson(String choice, JSONWriter writer) throws JSONException {
        writer.key("id").value(choice).key("text").value(choice);
    }

    @Override
    public Collection<String> toChoices(Collection<String> collection) {
        return collection;
    }
}
