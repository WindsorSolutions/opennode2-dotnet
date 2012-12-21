package com.windsor.node.plugin.test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.Reader;
import java.util.Iterator;

/**
 * Simple {@link Iterator} for walking through a file of SQL statements in a
 * well-defined layout.
 *
 */
public class SqlStatementIterator implements Iterator<String> {

	/**
	 * Start of a comment.
	 */
	private static final String COMMENT_START_REGEX = "^\\s*/\\*";

	/**
	 * End of a comment.
	 */
	private static final String COMMENT_END_REGEX = "\\*/\\s*$";

	/**
	 * Regular expression to skip the rest of a line.
	 */
	private static final String SKIP_REST_OF_LINE_REGEX = "--.*$";

	/**
	 * {@link Reader} into the file of SQL statements.
	 */
	private final BufferedReader reader;

	/**
	 * Separator between statements in a SQL file.
	 */
	private final String separator;

	/**
	 * Next statement to execute.
	 */
	private String nextStatement = null;

	/**
	 * Constructor.
	 *
	 * @param reader
	 *            {@link Reader} to the SQL statements
	 * @param separator
	 *            separator between statements in a SQL file
	 * @throws IOException
	 *             thrown if an error occurs creating a {@link Reader}
	 */
	public SqlStatementIterator(final Reader reader, final String separator) throws IOException {
		this.reader = new BufferedReader(reader);
		this.separator = separator;
	}

	@Override
	public boolean hasNext() {
		prepareNext();
		return nextStatement != null;
	}

	@Override
	public String next() {
		prepareNext();
		final String next = nextStatement;
		nextStatement = null;
		return next;
	}

	@Override
	public void remove() {
		throw new UnsupportedOperationException();
	}

	/**
	 * Parses the next statement from the SQL statement file if the next
	 * statement has yet to be parsed.
	 */
	private void prepareNext() {
		if (nextStatement == null) {
			nextStatement = parseNextStatement();
		}
	}

	/**
	 * Parses the next statement from the SQL statement file.
	 *
	 * @return Next statement to be executed
	 */
	private String parseNextStatement() {
		final StringBuilder sb = new StringBuilder();
		String nextLine = null;
		boolean inMultiLineComment = false;
		try {
			while ((nextLine = reader.readLine()) != null
					&& (inMultiLineComment || !nextLine.matches("^\\s*" + separator + "\\s*$"))) {

				if (nextLine.matches(COMMENT_START_REGEX)) {
					inMultiLineComment = true;
				}

				if (!inMultiLineComment) {
					nextLine = nextLine.replaceFirst(SKIP_REST_OF_LINE_REGEX, "");
					sb.append(nextLine);
					sb.append(" ");
				}

				if (nextLine.matches(COMMENT_END_REGEX)) {
					inMultiLineComment = false;
				}

			}
		} catch (final IOException e) {
			throw new RuntimeException(e);
		}

		/*
		 * Normalize space in the statement.
		 */
		final String s = sb.toString().replaceAll("\\s+", " ").trim();
		return s.length() == 0 ? null : s;
	}

}