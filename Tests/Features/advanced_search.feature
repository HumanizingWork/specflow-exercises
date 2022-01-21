Feature: Advanced Search

  Scenario: Exact Title Match
    When I do an advanced search with Title "How to Open Locks with Improvised Tools"
    Then the only result should be:
        | Field  | Value                                   |
        | Title  | How To Open Locks With Improvised Tools |
        | Author | Hans Conkel                             |
