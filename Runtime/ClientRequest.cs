/// <summary>
/// Enumeration of all the possible client request flags that can be sent to the server.
/// </summary>
/// Every request is documented in this format:
///     1. Description
///     2. Format - specifies what data will be sent after the flag is received.
public enum ClientRequest : byte {
    
    /// <summary> Sent to the server once the client wants to log-in. </summary>
    /// Format: [username] [password]
    Login,

    /// <summary> Sent to the server once the client wants to log-out. </summary>
    /// Format: [username]
    Logout,

    /// <summary> Sent to the server once the client wants to register a new account. </summary>
    /// Format: [username] [password]
    Register,

    /// <summary> Sent to the server once the client wants to create a new table. </summary>
    /// Format: [tableName] [smallBlind] [maxPlayers] [isRanked]
    CreateTable,

    /// <summary> Sent to the server once the client wants to join a specific table. </summary>
    /// Format: [tableName] [buyIn]
    JoinTable,

    /// <summary> Sent to the server once the client wants to leave the current table. </summary>
    /// Format: -
    LeaveTable,

    /// <summary> Sent to the server once the client wants to get the list of all the active tables. </summary>
    /// Format: -
    TableList,

    /// <summary> Sent to the server once the client wants to get data about specific client. </summary>
    /// Format: [username]
    ClientData,

    /// <summary> Sent to the server once the client checks. </summary>
    /// Format: -
    Check,

    /// <summary> Sent to the server once the client calls. </summary>
    /// Format: -
    Call,

    /// <summary> Sent to the server once the client raises. </summary>
    /// Format: [raiseAmount]
    Raise,

    /// <summary> Sent to the server once the client goes all-in. </summary>
    /// Format: -
    AllIn,

    /// <summary> Sent to the server once the client folds. </summary>
    /// Format: -
    Fold,
    
    /// <summary> Sent to the server to gracefully disconnect from the server. </summary>
    /// Format: -
    Disconnect,
    
    /// <summary> Sent to the server to check if the login reward is active. </summary>
    /// Format: -
    LoginReward,
    
    /// <summary> Sent to the server once the client wants to send the textual chat message. </summary>
    /// Format: [message]
    SendChatMessage,
}