namespace MapEngine
{
    interface IDice
    {
        int Roll(ICells cells, ICellSearch cellSearch);
    }
}