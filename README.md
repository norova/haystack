haystack
========

Note
----
I wrote this little utility a few years ago which means it is probably loaded with terrible coding practices and many, many undocumented features. However, I felt it was worth sharing with the world as it was a fun little project to work on.

What is haystack?
-----------------
haystack is an open-source tool written in C# which aims to improve your internet privacy by burying your web searches in a stack of false searches. It supports a number of different search engines and works by generating a random string at a random interval and sending the query to whichever search provider(s) you choose.

This project has only been tested in Windows XP, Windows Vista and Windows 7.

Currently supported search engines
----------------------------------
* AltaVista
* Answers.com
* Ask
* Bing
* Excite
* Google
* metacrawler
* WebMD
* Yahoo

Plans for the future
--------------------
I encourage anyone and everyone to take a look at my sloppy, out-of-date code and expand on it as you wish. One feature I originally had planned for this project was to generate better random search strings by parsing search results and learning from them as the program runs in the background, but I never got around to it.