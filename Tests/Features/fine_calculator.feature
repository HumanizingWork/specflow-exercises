Feature: Fine Calculator
  Fines need to be calculated accurately so that we’re fair to all our patrons
  while having an incentive to return books on time.

  Background:
    Given the standard fine per day is $0.25

  Scenario: No fines for on-time returns
    When the patron returns a book on time
    Then the there should be no fine

  Scenario: Fines for a late return
    When the patron returns a book 5 days late
    Then there should be a $1.25 fine
