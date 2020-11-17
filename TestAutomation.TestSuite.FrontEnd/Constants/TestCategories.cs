using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//THis class created to override default MSTEST category approach and provide category names as dot notadet values instead of values in quotes
public enum Category
{
    SmokeTest,
    ProductionSmokeTest,
    Regression,
    RegisterPerson,
    MAGI,
    State,
    Z_WorkInProgress
}

public class TestCategoryAttribute : TestCategoryBaseAttribute
{
    private readonly Category[] _categories;

    public TestCategoryAttribute(params Category[] categories)
    {
        _categories = categories;
    }

    public override IList<string> TestCategories
    {
        get { return _categories.Select(category => Enum.GetName(typeof (Category), category)).ToList(); }
    }
}