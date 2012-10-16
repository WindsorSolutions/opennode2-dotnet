package com.windsor.node.plugin.common.persistence;

/**
 * Abstract implementation of the {@link CriteriaFactory}. Handles the setting
 * of the data for the factory; the create method is left to the concrete
 * sub-classes.
 *
 * @param <DATA>
 * @param <ROOT>
 */
public abstract class AbstractCriteriaFactory<DATA, ROOT> implements CriteriaFactory<DATA, ROOT> {
	private DATA data;

	@Override
	@SuppressWarnings("unchecked")
	public void setUntypedData(final Object data) {
		this.data = (DATA) data;
	}

	@Override
	public void setData(final DATA data) {
		this.data = data;
	}

	/**
	 * Returns the data set for the factory.
	 *
	 * @return the data set for the factory
	 */
	protected DATA getData() {
		return data;
	}
}