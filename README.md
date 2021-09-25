# FinalProject.WebAPI
Our final project API workspace. Here is the readme 

The purpose of this readme is to explain this API, what we intended to do with it, and generally how to use it. 

Purpose of the API: 
  This API was created with the intent of allowing users to catalog, review, react to, and at the end of the day rate video games. This is done by using the crud method in Postman. Ideal. However, video games can act as a placeholder, and this API can be used as a shell of sorts for anyone trying to store, create, and retrieve different types of data. There are four main parts to this API: the video games, the reaction, the reviews, and the user. 
  
How to utilize: 

  When users first come across this API, they must create a user account and password using Postman. This is done by requesting a key through Postman and creating a login using the said key.
  
  Once a user has created a profile, they will have access to the three other functions within the API. Using the crud method, the user can create a game, review, or reaction tied to their account. For example, a user can create the game "Skyrim" (the API will prompt the user with some other information) and be the game owner within the API. However, a separate user can create the game Pokémon and be the owner of this game within the API. As long as users know the GUID for each game, they can access each game within the API and post reviews and reactions tied to their accounts. Because they are not the game owner within the API, the guest users won't be able to edit the individual games. In our example from before, user A would be able to edit the base data for Pokemon, and user B wouldn't be able to edit the base data for Skyrim. This is performed by creating rules within the code that explicitly tie editing rights to users who entered the API game. 
  
  The possibilities for this type of data entry are tremendous as it allows users to browse by game type, user id, reactions, genre, etc. It also utilizes containerization to help minimize the amount of unauthorized editing available. The base code is also intuitive enough to allow administrators to edit the access rights as they fit. We tried to balance control, security, and flexibility within our API setup. 
  
  Future Goals:
  
  We have multiple future goals for this API that we wish to explore. This includes adding a front-end interface, using an external data set as the seed data, instituting asyncronise programming into the API, and adding different data tables (such as cheat codes, guidebooks, or walkthroughs for the various games). We are currently in the process of exploring and building out these outside capabilities. 
  
  If anyone has any questions about our API, please do not hesitate to reach out!
  
  For Further research please reference the links below
  
  Google Planning Doc: https://docs.google.com/document/d/1tZM32K1eSXw5MHtgB99oErnEAlreUkEdvnNFr3Zt1nE/edit
  
  DbDiagram: https://dbdiagram.io/d/611c493e2ecb310fc3cfb266
  
  Trello: https://trello.com/b/o81zqS1g/board-1
