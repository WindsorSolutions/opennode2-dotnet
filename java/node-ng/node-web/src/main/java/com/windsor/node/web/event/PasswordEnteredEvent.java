package com.windsor.node.web.event;

/**
 * Provides an event indicating that a password was entered.
 */
public class PasswordEnteredEvent {

    private boolean correct;

    public PasswordEnteredEvent(boolean correct) {
        this.correct = correct;
    }

    public boolean isCorrect() {
        return correct;
    }
}
