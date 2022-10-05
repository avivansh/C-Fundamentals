namespace GradeBook.Tests;

using System;
using Xunit;
public class TypeTests
{
    [Fact]
    public void GetBookReturnsDifferentBookObjects()
    {

        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);

    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {

        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 1", book2.Name);
        Assert.Same(book1, book2);
        Assert.True(object.ReferenceEquals(book1, book2));


    }

    [Fact]
    public void CanSetNameFromReference()
    {

        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);

    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact]
    public void IsPassByValue()
    {

        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
        //Always Always Always parameters are passed by values until and unless it is passed by reference

    }

    [Fact]
    public void CanPassByReference()
    {

        var book1 = GetBook("Book 1");
        GetBookSetNameByRef(ref book1, "New Name"); // now we are here explicitly passing the book object as a reference not as a copy


        Assert.Equal("New Name", book1.Name); // since passed by reference it is expected that name should change
        //Always Always Always parameters are passed by values until and unless it is passed by reference

    }

    private void GetBookSetNameByRef(ref Book book, string name)
    {
        // book -----> book1
        book = new Book(name);
        //book1 -----> newly created book

    }

    private void GetBookSetName(Book book, string name)
    {
        // book -----> book1
        book = new Book(name);
        //book -----> newly created book

    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}