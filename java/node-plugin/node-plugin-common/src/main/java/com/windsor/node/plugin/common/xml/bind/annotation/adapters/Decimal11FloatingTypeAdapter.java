package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

/**
 * {@link XMLAdapter} for handling *Decimal11FloatingType* types.
 *
 */
public class Decimal11FloatingTypeAdapter extends AbstractBigDecimalLengthAdapter {

	@Override
	protected int totalNumberOfCharacters() {
		return 11;
	}

}
