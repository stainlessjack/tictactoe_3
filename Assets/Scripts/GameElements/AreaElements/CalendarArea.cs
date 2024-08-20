namespace GameElements
{
    public class CalendarArea : AreaElement
    {
        // The Calendar Area is the representation of the calendar area in the game
        // it is composed of 3 zones: the day deck, the day discard, and the crematorium
        // (or global discard pile)
        public DeckZone dayDeck;
        public DiscardZone dayDiscard;
        public DiscardZone crematorium;

        // Initialize the data given an existing calendar area
        public void Initialize(CalendarArea calendarArea)
        {
            // Initialize the area element
            base.Initialize(calendarArea);

            // Initialize the calendar area
            dayDeck.Initialize(calendarArea.dayDeck);
            dayDiscard.Initialize(calendarArea.dayDiscard);
            crematorium.Initialize(calendarArea.crematorium);
        }

        // Initialize the data given the dayDeck, dayDiscard, and crematorium
        public void Initialize(DeckZone dayDeck, DiscardZone dayDiscard, DiscardZone crematorium)
        {
            // Initialize the area element
            base.Initialize(AreaType.CALENDAR, "CalendarBoard");

            // Initialize the calendar area
            this.dayDeck.Initialize(dayDeck);
            this.dayDiscard.Initialize(dayDiscard);
            this.crematorium.Initialize(crematorium);
        }
    }
}