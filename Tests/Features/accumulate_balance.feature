Feature: Accumulate a fine/fee balance on library cards
  In order to keep track of what patrons owe

  Background:
    Given a new patron, John, has joined the library

  Scenario: Patrons start with $0 balance
    When John checks his account balance
    Then the balance should be $0.00

  Scenario: Track fines on patron accounts
    Given John has been fined $0.50 for a late return
    When John checks his account balance
    Then the balance should be $0.50

  Scenario: Fees and fines both get added to the balance
    Given John has been fined $0.75 for a late return
    And John has been charged $20 for a lost book
    When John checks his account balance
    Then the balance should be $20.75
