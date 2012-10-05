package com.windsor.node.plugin;

import java.io.IOException;
import java.io.Reader;
import java.util.Iterator;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.collections.IteratorUtils;
import org.apache.commons.collections.Transformer;

/**
 * Factory for creating {@link Iterator}s over Oraclr SQL statements for use in
 * an HSQLDB DB.
 *
 */
public class HsqldbOracleStatementIteratorFactory {

	/**
	 * Instance of the Hsqldb <- Oracle SQL transformer.
	 */
	private static final Transformer SQL_TRANSFORMER = new HsqldbOracleSqlStatementTransformer();

	/**
	 * Oracle statement separator.
	 */
	private static final String STATEMENT_SEPARATOR = "/";

	/**
	 * Singleton instance of the class.
	 */
	private static HsqldbOracleStatementIteratorFactory instance = new HsqldbOracleStatementIteratorFactory();

	/**
	 * Returns the singleton instance of the class.
	 *
	 * @return the singleton instance of the class
	 */
	public static HsqldbOracleStatementIteratorFactory instance() {
		return instance;
	}

	/**
	 * Creates a new {@link Iterator} instance over the SQL statements in the
	 * {@code reader}.
	 *
	 * @param reader
	 *            {@link Reader} containing the SQL statements
	 * @return new {@link Iterator} instance over the SQL statements in the
	 *         {@code reader}
	 * @throws IOException
	 *             thrown if an error occurs reading the SQL statements from the
	 *             {@code reader}
	 */
	@SuppressWarnings("unchecked")
	public Iterator<String> create(final Reader reader) throws IOException {
		final HsqldbOracleStatementIterator it = new HsqldbOracleStatementIterator(reader);
		return IteratorUtils.transformedIterator(it, SQL_TRANSFORMER);
	}

	/**
	 * Extension of {@link SqlStatementIterator}, specifying the SQL statement
	 * separator.
	 *
	 */
	private static class HsqldbOracleStatementIterator extends SqlStatementIterator {
		public HsqldbOracleStatementIterator(final Reader reader) throws IOException {
			super(reader, STATEMENT_SEPARATOR);
		}
	}

	/**
	 * Implementation of {@link Transformer} which specifies how to transform
	 * Oracle SQL into HSQLDB SQL.
	 *
	 */
	private static class HsqldbOracleSqlStatementTransformer implements Transformer {

		/**
		 * Regex for removing incompatible parts of statements that aren't
		 * compatible with HSQLDB.
		 */
		private static final Pattern CONSTAINT_REGEX = Pattern
				.compile("^(.*)ADD\\s+\\(\\s+CONSTRAINT(.*)NOT DEFERRABLE INITIALLY IMMEDIATE.*\\)(.*)$");

		@Override
		public Object transform(final Object t) {
			String s = t.toString();
			final Matcher m = CONSTAINT_REGEX.matcher(s);
			if (m.matches()) {
				s = m.group(1) + "ADD CONSTRAINT" + m.group(2) + m.group(3);
			}
			return s;
		}

	}

}
