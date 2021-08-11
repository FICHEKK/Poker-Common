/// <summary>
/// Enumeration of all the possible server response flags that can be sent to the client.
/// </summary>
/// Every response is documented in this format:
///     1. Description
///     2. Format - specifies what data will be sent after the flag is received.
///        For example, if there was enumeration constant called "Book" and its format was [title] [text], that
///        would mean that once the client receives ServerResponse.Book, it can immediately after expect book's
///        title and book's text.
///        [data]* - client can expect this field to be sent from 0 to infinite number of times.
///     3. Type - can be signal or broadcast.
///        Signal is sent to a single client.
///        Broadcast is sent to a group of clients.
public enum ServerResponse : byte {

    #region Player decision

    /// <summary>Sent to all the players (at the same table) every time a player checks.</summary>
    /// Format: -
    /// Type: broadcast
    PlayerChecked,

    /// <summary>Sent to all the players (at the same table) every time a player calls.</summary>
    /// Format: [callAmount]
    /// Type: broadcast
    PlayerCalled,

    /// <summary>Sent to all the players (at the same table) every time a player raises.</summary>
    /// Format: [raisedToAmount]
    /// Type: broadcast
    PlayerRaised,

    /// <summary>Sent to all the players (at the same table) every time a player goes all-in.</summary>
    /// Format: -
    /// Type: broadcast
    PlayerAllIn,

    /// <summary>Sent to all the players (at the same table) every time a player folds.</summary>
    /// Format: -
    /// Type: broadcast
    PlayerFolded,

    #endregion

    #region Player presence

    /// <summary>Sent to all the players (at the same table) every time a new player joins the table.</summary>
    /// Format: [joiningPlayerIndex] [username] [chipCount]
    /// Type: broadcast
    PlayerJoined,

    /// <summary>Sent to all the players (at the same table) every time a player leaves the table.</summary>
    /// Format: [leavingPlayerIndex]
    /// Type: broadcast
    PlayerLeft,

    #endregion

    #region Round phases

    /// <summary>Sends the hand cards to the specific player.</summary>
    /// Format: [card] [card]
    /// Type: signal
    Hand,

    /// <summary>Sends the flop cards to all the players at the same table.</summary>
    /// Format: [card] [card] [card]
    /// Type: broadcast
    Flop,

    /// <summary>Sends the turn card to all the players at the same table.</summary>
    /// Format: [card]
    /// Type: broadcast
    Turn,

    /// <summary>Sends the river card to all the players at the same table.</summary>
    /// Format: [card]
    /// Type: broadcast
    River,
    
    /// <summary>Indicates that the round has finished and showdown is about to begin.</summary>
    /// Format: [sidePotCount] ([sidePotValue] [winnerCount] [winnerIndexes]* [bestHandValue])*
    /// Type: broadcast
    Showdown,

    /// <summary>Sent to all the players (at the same table) indicating that the current round has finished.</summary>
    /// Format: -
    /// Type: broadcast
    RoundFinished,

    #endregion

    /// <summary>Message to all the players (at the same table) saying which players need to place blinds this round.</summary>
    /// Format: [dealerButtonIndex] [smallBlindPlayerIndex] [bigBlindPlayerIndex]
    /// Type: broadcast
    Blinds,
    
    /// <summary>Sent to all the players (at the same table) indicating which player is now deciding.</summary>
    /// Format: [currentPlayerIndex]
    /// Type: broadcast
    PlayerIndex,
    
    /// <summary>Message to the current player which indicates the required bet needed to continue playing.</summary>
    /// Format: [requiredBetAmount]
    /// Type: single
    RequiredBet,
    
    /// <summary>Sent to the client that has just logged in and is eligible for a login reward.</summary>
    /// Format: [rewardAmount]
    /// Type: single
    LoginRewardActive,
    
    /// <summary>Sent to the client that has just logged in, but the award is not yet active.</summary>
    /// Format: [timeUntilReward]
    /// Type: single
    LoginRewardNotActive,

    /// <summary>Sent to every client at the end of the round where the cards are being revealed.</summary>
    /// Format: [cardPairCount] ([playerIndex] [card1] [card2])*
    /// Type: broadcast
    CardsReveal,
    
    /// <summary>Textual chat message sent to every client at the table.</summary>
    /// Format: [playerIndex] [message]
    /// Type: broadcast
    ChatMessage,
    
    /// <summary>Sent to the client once the client joined the table and needs to build the table scene.</summary>
    /// Format: [dealerIndex] [smallBlind] [maxPlayers] [playerCount] ([index] [username] [stack] [bet] [folded])* [cardCount] [card]* [playerIndex] [pot]
    /// Type: single
    TableState,
    
    
    
    

    #region Leaving the table
    
    /// <summary>Sent to the client once it is time to leave the table.</summary>
    /// Format: [LeaveTableGranted | LeaveTableNoMoney | LeaveTableRanked]
    /// Type: single
    LeaveTable,
    
    /// <summary>Sent to the client once the table leaving was successful on the standard table.</summary>
    /// Format: -
    /// Type: single
    LeaveTableGranted,

    /// <summary>Sent to the client once the said client goes bankrupt on the standard table.</summary>
    /// Format: -
    /// Type: single
    LeaveTableNoMoney,
    
    /// <summary>Sent to the client once the said client leaves the ranked table.</summary>
    /// Format: [placeFinished] [oldRating] [newRating]
    /// Type: single
    LeaveTableRanked,

    #endregion





    #region Login

    /// <summary>Sent to the player if the login was successful.</summary>
    LoginSuccess,

    /// <summary>Sent to the player if the login failed because the username is not registered in the database.</summary>
    LoginUsernameNotRegistered,

    /// <summary>Sent to the player if the login failed because of the wrong password.</summary>
    LoginWrongPassword,

    /// <summary>Sent to the player if the login failed because the server is full and cannot accept any more clients.</summary>
    LoginServerFull,

    /// <summary>Sent to the player if the login failed because the client with the specified username is already logged in.</summary>
    LoginAlreadyLoggedIn,

    /// <summary>Sent to the player if the login failed because the client with the specified username is banned.</summary>
    LoginUsernameBanned,
    
    #endregion





    #region Registration

    /// <summary>Sent to the player if the registration was successful.</summary>
    RegistrationSuccess,

    /// <summary>Sent to the player if the registration failed because of the database error on the server side.</summary>
    RegistrationDatabaseError,

    /// <summary>Sent to the player if the registration failed because the requested username is already taken.</summary>
    RegistrationUsernameTaken,

    #endregion





    #region Join table

    /// <summary>Sent to the player if the joining was successful.</summary>
    JoinTableSuccess,
    
    /// <summary>Sent to the player if the joining failed because the selected table is full.</summary>
    JoinTableTableFull,
    
    /// <summary>Sent to the player if the joining failed because the selected table does not exist.</summary>
    JoinTableTableDoesNotExist,
    
    /// <summary>Sent to the player if the joining failed because the selected ranked table match has already started.</summary>
    JoinTableRankedMatchStarted,

    #endregion





    #region Create table

    /// <summary>Sent to the player if the requested table creation was successful.</summary>
    CreateTableSuccess,

    /// <summary>Sent to the player if the requested table was not created because the table title is already taken.</summary>
    CreateTableTitleTaken

    #endregion
}
