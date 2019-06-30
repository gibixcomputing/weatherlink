# CONTRIBUTING
First off, thank you for looking at this repository and thinking of
contributing! Libraries like this one always benefit from more eyes and
collaboration.

That being said, this project is starting off as a pet project of mine to
allow me to interface directly with my weather station to collect weather data
and to eventually allow uploading and viewing the collected data.

Feel free to open any issues needed to track feature requests or bugs. I am
developing this on my own personal time, so there may be a delay in responses.
However, I want this to be a successful library, so I will try to be as prompt
as my personal life allows. Feel free to fork the project and submit pull
requests as you see fit.

Keep in mind, this is a very early project, so expect the projects, structure,
and code to be very fluid. I do have a road map, but I do try to keep up with
the latest in code structure and techniques, which may cause larger changes. I
will try to be clear in commit messages and comments what is happening and why.

## GUIDELINES
This project generally follows the recommendations and coding guidelines set
forth in CoreFX repository in the .NET Foundation. The files
[`.editorconfig`](/.editorconfig), [`.gitattributes`](/.gitattributes), and
[`.gitignore`](/.gitignore) were sourced from their repository to provide a
solid base for initial development.

Commit messages should generally follow the 50/72 format to allow clear
communication on what a particular commit does and any rationale, if needed.
Tim Pope has written some good guidelines in
[A Note About Git Commit Messages](https://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html).
The information contained at this page is well worth the read. Good commit
hygine is a great thing!

## VERSIONING
While this project is just getting started, it will eventually track changes
via a standard VERSIONS file located in the repository. This will follow the
industry standard semantic versioning system to represent breaking changes,
backwards compatible changes, and patches.

## BRANCHING
The master branch will always contain the latest development code and track
any upcoming releases. While Git Flow isn't going to be explicitly followed it
will use the standard feature branching names and integrate code via pull
requests.

Features will be stored under `/feature/` branches, issues will be in
`/bugfix/` branches. Other branches may pop up from time to time, such as an
`/ops/` branch to coordinate larger refactorings that do not change the logic
of the code and can be used for upgrading dependencies or other project
structure changes.
