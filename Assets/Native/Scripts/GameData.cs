public static class GameData
{
    private static int enemyAmount = 10;
    private static int swordAddItemCount = 30;
    private static int healItemCount = 5;
    private static int moveSpeedItemCount = 5;
    private static int swordSpeedItemCount = 5;
    
    private static float mapSizeX = 55;
    private static float mapSizeZ = 55;
    
    public static int EnemyAmount
    {
        get => enemyAmount;
        
        private set => enemyAmount = value;
    }
    
    public static int SwordAddItemCount
    {
        get => swordAddItemCount;
        
        private set => swordAddItemCount = value;
    }
    
    public static int HealItemCount
    {
        get => healItemCount;
        
        private set => healItemCount = value;
    }
    
    public static int MoveSpeedItemCount
    {
        get => moveSpeedItemCount;
        
        private set => moveSpeedItemCount = value;
    }
    
    public static int SwordSpeedItemCount
    {
        get => swordSpeedItemCount;
        
        private set => swordSpeedItemCount = value;
    }
    
    public static float X
    {
        get => mapSizeX;
        
        private set => mapSizeX = value;
    }
    
    public static float Z
    { 
        get => mapSizeZ;
        
        private set => mapSizeZ = value;
    }
}
