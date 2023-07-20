using bielu.multiRummykub.Models.Table;
using bielu.multiRummykub.Server.DbContexts;
using bielu.multiRummykub.Server.Services;
using Moq;

namespace bielu.multiRummykub.UnitTests.Services;

public class TableServiceTests
{
    /*
    [Fact]
    public void CreateTable_2Players_Duplicates_106Cubes()
    {

        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(2, ScaleType.Duplicates);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_2Players_Colors_106Cubes()
    {
        var mockTableDb = new Mock<AppDbContext>();
        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(2, ScaleType.Colors);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_3Players_Duplicates_106Cubes()
    {

        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(3, ScaleType.Duplicates);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_3Players_Colors_106Cubes()
    {
        var mockTableDb = new Mock<TableDbContext>();
        var mockPlayerDb = new Mock<PlayerDbContext>();
        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(3, ScaleType.Colors);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_4Players_Duplicates_106Cubes()
    {

        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(4, ScaleType.Duplicates);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_4Players_Colors_106Cubes()
    {
        var mockTableDb = new Mock<TableDbContext>();
        var mockPlayerDb = new Mock<PlayerDbContext>();
        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(4, ScaleType.Colors);
        Assert.Equal(106, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_6Players_Duplicates_160Cubes()
    {

        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(6, ScaleType.Duplicates);
        Assert.Equal(160, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_6Players_Colors_160Cubes()
    {
        var mockTableDb = new Mock<TableDbContext>();
        var mockPlayerDb = new Mock<PlayerDbContext>();
        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(6, ScaleType.Colors);
        Assert.Equal(160, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_8Players_Duplicates_212Cubes()
    {

        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(8, ScaleType.Duplicates);
        Assert.Equal(212, table.Cubes.Count);
    }
    [Fact]
    public void CreateTable_8Players_Colors_212Cubes()
    {
        var mockTableDb = new Mock<TableDbContext>();
        var mockPlayerDb = new Mock<PlayerDbContext>();
        var tableService = new TableService(null,null);
        var table = tableService.CreateTable(8, ScaleType.Colors);
        Assert.Equal(212, table.Cubes.Count);
    }
    */
}