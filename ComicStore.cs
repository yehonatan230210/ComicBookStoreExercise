namespace ComicBookStore;

/// <summary>
/// מחלקת חנות ספרי הקומיקס - מכילה את האוספים והפעולות שהתלמידים יידרשו לממש.
/// </summary>
public class ComicStore
{
    // רשימת חוברות הקומיקס בחנות
    public List<ComicBook> Inventory { get; private set; }

    public ComicStore()
    {
        Inventory = new List<ComicBook>();
        InitializeInventory();
    }

    /// <summary>
    /// אתחול החנות עם 20 חוברות קומיקס שונות (כולל חוברות עם מלאי 0)
    /// </summary>
    private void InitializeInventory()
    {
        Inventory.Add(new ComicBook("The Amazing Spider-Man #300", 1988, "Spider-Man", 5));
        Inventory.Add(new ComicBook("Batman: The Dark Knight Returns", 1986, "Batman", 0));
        Inventory.Add(new ComicBook("Superman: Action Comics #1000", 2018, "Superman", 12));
        Inventory.Add(new ComicBook("X-Men #1", 1991, "X-Men", 8));
        Inventory.Add(new ComicBook("Wonder Woman #1", 2016, "Wonder Woman", 0));
        Inventory.Add(new ComicBook("Deadpool: Kills the Marvel Universe", 2012, "Deadpool", 3));
        Inventory.Add(new ComicBook("Iron Man: Demon in a Bottle", 1979, "Iron Man", 2));
        Inventory.Add(new ComicBook("The Flash: Flashpoint", 2011, "The Flash", 7));
        Inventory.Add(new ComicBook("Thor: God of Thunder #1", 2012, "Thor", 0));
        Inventory.Add(new ComicBook("Captain America: Winter Soldier", 2005, "Captain America", 4));
        Inventory.Add(new ComicBook("Spider-Man: Blue", 2002, "Spider-Man", 10));
        Inventory.Add(new ComicBook("Batman: Year One", 1987, "Batman", 6));
        Inventory.Add(new ComicBook("Wolverine: Weapon X", 1991, "Wolverine", 0));
        Inventory.Add(new ComicBook("Black Panther: A Nation Under Our Feet", 2016, "Black Panther", 9));
        Inventory.Add(new ComicBook("Spider-Gwen #1", 2015, "Spider-Man", 1));
        Inventory.Add(new ComicBook("Doctor Strange: The Way of the Weird", 2015, "Doctor Strange", 4));
        Inventory.Add(new ComicBook("Fantastic Four #48", 1966, "Fantastic Four", 0));
        Inventory.Add(new ComicBook("Daredevil: Born Again", 1986, "Daredevil", 3));
        Inventory.Add(new ComicBook("Venom: Lethal Protector", 1993, "Venom", 11));
        Inventory.Add(new ComicBook("Harley Quinn: Mad Love", 1994, "Harley Quinn", 0));
    }

    // =========================================================================
    // מתודות מיועדות לתרגול התלמידים (מגיעות כרגע עם מימוש ריק / מחזירות ערך ברירת מחדל)
    // =========================================================================

    /// <summary>
    /// משימה 1: הוספת חוברת קומיקס חדשה לחנות.
    /// אם החוברת כבר קיימת (לפי שם), יש להגדיל את המלאי בכמות שמתקבלת.
    /// אם החוברת לא קיימת, יש להוסיף אותה לרשימה.
    /// </summary>
    public void AddOrUpdateComic(ComicBook newComic)
    {
        foreach(ComicBook c in Inventory)
        {
            if (c.Title == newComic.Title)
            {
                c.StockQuantity += newComic.StockQuantity;
                return;
            }
        }
                Inventory.Add(newComic);
    }

    /// <summary>
    /// משימה 2: עדכון כמות המלאי של חוברת קומיקס קיימת לפי שמה.
    /// מחזיר true אם התיקון בוצע, false אם הספר לא נמצא במלאי.
    /// </summary>
    public bool UpdateStock(string title, int newQuantity)
    {
        foreach(ComicBook c in Inventory)
        {
            if(c.Title == title)
            {
                c.StockQuantity = newQuantity;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// משימה 3: החזרת רשימה של כל החוברות של גיבור מסוים.
    /// </summary>
    public List<ComicBook> SearchByHero(string heroName)
    {
        List<ComicBook> heroComics = new List<ComicBook>();
        foreach(ComicBook c in Inventory)
        {
            if(c.Hero == heroName)
            {
                heroComics.Add(c);
            }
        }
        return heroComics;
    }

    /// <summary>
    /// משימה 4: בדיקה האם חוברת קומיקס קיימת ובמלאי (כמות מלאי גדולה מ-0).
    /// </summary>
    public bool IsInStock(string title)
    {
        foreach(ComicBook c in Inventory)
        {
            if(c.Title == title && c.StockQuantity > 0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// משימה 5: החזרת מילון שבו המפתח הוא שם החוברת (Title) והערך הוא הכמות במלאי (StockQuantity).
    /// </summary>
    public Dictionary<string, int> GetStockDictionary()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();
        foreach(ComicBook c in Inventory)
        {
            stock.Add(c.Title, c.StockQuantity);
        }
        return stock;   
    }

    /// <summary>
    /// משימה 6: חיפוש כמות במלאי עבור ספר נתון באמצעות המילון.
    /// **חובה**: להשתמש בתוך הפעולה בזימון של GetStockDictionary() שמימשתם בסעיף 5!
    /// אם הספר קיים במילון - החזר את הכמות. אם לא - החזר -1.
    /// </summary>
    public int GetQuantityFromDictionary(string title)
    {
        Dictionary<string, int> stock = GetStockDictionary();
        if(stock.ContainsKey(title))
        {
            return stock[title];
        }
        
        return -1;
    }

    /// <summary>
    /// משימה 7 (בונוס): החזרת שם הגיבור שיש לו הכי הרבה חוברות קומיקס בחנות (ללא קשר לכמות במלאי).
    /// רמז: מומלץ להיעזר במילון לספירת חוברות לכל גיבור!
    /// </summary>
    public string GetHeroWithMostComics()
    {
        // TODO: התלמידים יכתבו את הקוד כאן
        return string.Empty;
    }
}
