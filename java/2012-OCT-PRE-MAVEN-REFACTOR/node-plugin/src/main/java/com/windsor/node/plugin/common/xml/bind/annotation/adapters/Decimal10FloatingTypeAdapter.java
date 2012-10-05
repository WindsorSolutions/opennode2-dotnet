package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

/**
 * {@link XMLAdapter} for handling *Decimal10FloatingType* types.
 *
 */
public class Decimal10FloatingTypeAdapter extends AbstractBigDecimalLengthAdapter {

	@Override
	protected int totalNumberOfCharacters() {
		return 10;
	}

}
