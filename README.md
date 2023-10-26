# JeffersonCountyLibrary

## Setup
* Fork and Clone this repository
* Run `update-database`

## Exercise (12 points)

Check out a new branch and complete the following tasks **in order**:
* 2 points - There is a bug in our authentication!  Identity looks like it is set up, but we can't register users.  Find and fix this bug! (Hint: this should only take one line of code)
* 2 points - Right now, anyone can 'check out' a book.  Update the application so that only a logged in user can check out a book.
* 4 points - In this application, we have the ability to create new books.  Improve this functionality by:
  * Add a link from the nav-bar to add a book
  * Make sure only Librarians can add a book
* 2 points - Create a descriptive pull request and merge this branch into main
* 2 points - Take a screenshot of a database query result from pgAdmin that clearly shows which users in your database are librarians.  Update this README to include your screenshot below:

  < YOUR SCREENSHOT SHOULD GO HERE >

  

## Questions (6 points)

Answer the questions below in this README.  Answer these questions as if you are in an interview!

1. What are roles and claims as they relate to Authentication and Authorization?
* Claims and roles are how we can use authorization throughout our programs. Roles allow us to decide which users have access to which pages or views over a long period of time, compared to claims which act similarly but are meant for conditions that frequently change such as birthdays.
* Authorization generally speaking, takes place after a user has been authenticated. So, I like to think of it as 'is this user logged in, if so what can they access?"
* In order to implement roles we can assign an [Authorize] attribute to individual actions in our controllers or the controller as a whole. Authorize can take an argument where you can assign it a role, `[Authorize(Roles = "Admin")]` I believe that this is also how claims are used, but I am a bit rusty with those as roles have provided more structure for me so far.
* To break it down further in clear terms, roles and claims both provide guidelines on what a user can do or access, but roles are meant to outline long-term permissions such as 'who can add data?" or "who can view this page?" Whereas claims are meant to provide temporary permissions, such as if its a user's birthday that user now has permission to use a discount code at checkout, but the next day, they no longer have access to that code.

3. How do cookies play a role in authentication and authorization?
* I see cookies as the glue that holds auth together for large sites. First, cookies can provide storage for Session IDs which will allow us to track all users - not just those logged in which can allow us to customize their preferences/permissions without forcing them to have an account.
* Additionally, cookies can store client-side preferrences (dark mode, or language for example) which can be used in conjunction with authorization to provide more personal experiences. Let's say we have a large global application, and in this application we have users speaking a dozen languages, for each one we could create a role for that language. Now, we can use cookies to grab the user's preferences so that we can display the proper pages in their language.
* Additionally for something similar, Dark Mode is a setting that is frequently changed - this can be used with claims inside the views to update what the user sees based on the value of the 'theme' cookie.
* Cookies are essential to the maintainability of authorization and authentication, as they let us go one step further to providing catered experiences to all of our users - registered or not.

5. If asked to implement Auth in a new .NET application, would you use the Identity framework?
* If I were to implement new Auth, I would go with Identity for a few reasons: first, I'm most familiar with this method so I know that I would be able to implmement it in a timely manner. Second, Identity does a lot to take the weight off of the devs shoulders by scaffolding much of the pages and logic for us.
* Now, the second reason could also be seen as a negative in that if we needed a lot of customization it may be easier to take a different approach (or just not use the scaffolding).
* While I am partial to Identity, the reality is that with time and documentation I could figure out how to implemement auth through another framework if needed.

## Rubric

This assessment has a total of 18 points.  Earning 12 or higher is a pass!
