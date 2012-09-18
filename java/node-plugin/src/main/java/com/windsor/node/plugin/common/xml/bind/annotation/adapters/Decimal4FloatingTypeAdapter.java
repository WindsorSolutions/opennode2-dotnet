package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

/**
 * {@link XMLAdapter} for handling *Decimal4FloatingType* types.
 *
 */
public class Decimal4FloatingTypeAdapter extends AbstractBigDecimalLengthAdapter {

	@Override
	protected int totalNumberOfCharacters() {
		return 4;
	}

	@Override
	protected int maxPrecision() {
		return 2;
	}

}
