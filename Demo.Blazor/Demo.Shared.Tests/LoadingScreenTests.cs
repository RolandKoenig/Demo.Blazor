using Bunit;
using Demo.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Shared.Tests
{
    [TestClass]
    public class LoadingScreenTests
    {
        [TestMethod]
        public void Check_LoadingScreen_Title()
        {
            using var textCtx = new Bunit.TestContext();
            var rendered = textCtx.RenderComponent<LoadingScreen>(
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreen.Title), "Test-Title"));

            var titleElement = rendered.Find("h2");
            
            Assert.IsNotNull(titleElement);
            Assert.IsTrue(titleElement.InnerHtml == "Test-Title");
        }

        [TestMethod]
        public void Check_LoadingScreen_Animation()
        {
            using var textCtx = new Bunit.TestContext();
            var rendered = textCtx.RenderComponent<LoadingScreen>(
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreen.Title), "Test-Title"));

            var loadingElement = rendered.Find("div.cssload-thecube");

            Assert.IsNotNull(loadingElement);
        }

        [TestMethod]
        public void Check_LoadingScreen_Switch_True()
        {
            var childContentBuilder = new RenderFragment((RenderTreeBuilder builder) =>
            {
                builder.OpenElement(0, "h2");
                builder.AddContent(1, "Test-Content");
                builder.CloseElement();
            });

            using var textCtx = new Bunit.TestContext();
            var rendered = textCtx.RenderComponent<LoadingScreenSwitch>(
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreenSwitch.IsLoading), true),
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreenSwitch.ChildContent), childContentBuilder));

            var loadingElement = rendered.Find("div.cssload-thecube");

            Assert.IsNotNull(loadingElement);
        }

        [TestMethod]
        public void Check_LoadingScreen_Switch_False()
        {
            var childContentBuilder = new RenderFragment((RenderTreeBuilder builder) =>
            {
                builder.OpenElement(0, "h2");
                builder.AddContent(1, "Test-Content");
                builder.CloseElement();
            });

            using var textCtx = new Bunit.TestContext();
            var rendered = textCtx.RenderComponent<LoadingScreenSwitch>(
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreenSwitch.IsLoading), false),
                Bunit.Rendering.ComponentParameter.CreateParameter(nameof(LoadingScreenSwitch.ChildContent), childContentBuilder));

            var titleElement = rendered.Find("h2");

            Assert.IsNotNull(titleElement);
            Assert.IsTrue(titleElement.InnerHtml == "Test-Content");
        }
    }
}
