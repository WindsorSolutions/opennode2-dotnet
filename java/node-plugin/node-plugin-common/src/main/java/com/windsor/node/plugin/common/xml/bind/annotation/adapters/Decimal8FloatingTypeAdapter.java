package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

/**
 * {@link XMLAdapter} for handling *Decimal8FloatingType* types.
 *
 */
public class Decimal8FloatingTypeAdapter extends AbstractBigDecimalLengthAdapter {

	@Override
	protected int totalNumberOfCharacters() {
		return 8;
	}

}
