using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string input = "";
        string[] expectedResult = Array.Empty<string>();

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string input = "hello";
        string[] expectedResult = {"hello"};

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string input = "hello, how, are, you";
        string[] expectedResult = { "hello", "how", "are", "you" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string input = " hello  ,   how  , are ,   you  ";
        string[] expectedResult = { "hello", "how", "are", "you" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    [Test]
    public void Test_ParseCsv_OnlyDelimiters_ReturnsArrayOfEmptyStrings()
    {
        // Arrange
        string input = ",,,,";
        string[] expectedResult = { "", "", "", "", "" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

}
