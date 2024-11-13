using HackerNews.Domain.Exceptions;
using HackerNews.Domain.ValueObjects;
using Shouldly;

namespace HackerNews.Tests.Unit.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("https://thehill.com/homenews/campaign/4969061-trump-wins-presidential-election/")]
    [InlineData("https://maxsiedentopf.com/passport-photos/")]
    [InlineData("https://weiyen.net/articles/useful-macos-cmd-line-utilities")]
    public void give_valid_string_url_creation_should_succeed(string urlString)
    {
        var url = new URL(urlString);
        url.ShouldNotBeNull();
        url.Value.ShouldBeEquivalentTo(urlString);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1111111111111111111111")]
    [InlineData("isbn446877428ydh")]
    public void given_invalid_string_url_creation_should_fail(string urlString)
    {
        var exception = Record.Exception(() => new URL(urlString));
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidUrlException>();
    }
}