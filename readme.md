### Synopsis
The Tilted Globe App provides a marketplace for viewers(general public) and producers to view and stream content.  The application integrates with WireCast, Akamai and a web browser to make this happen. We only guarantee functionality on the latest browser versions IE 10 and up and the latest version of Chrome although they would like it to be workable with mobile devices. The designs for the app are on http://yubxy0.axshare.com/#p=login_landing_page&c=1, and there is a Surge dropbox directory with further documentation.

### Technology Overview
The main players of the application on the backend are Asp.Net MVC/Web.API, Entity Framework and SqlServer. MVC is merely used to serve the templates, there is no server side rendering - the API just handles ajax communication. The main player on the frontend is AngularJS.   The routing on the MVC side is handeled by the ModulesController and will only serve up master pages when a particular URL is browsed to directly or page is refreshed otherwise templates will be fetched and Angular-UI will take care of state management.  Right now the master pages include Index.cshtml and Producer.cshtml - these are both seperate ng-apps and contain all the CSS/Javascript include files.  



### Directory Structure
The structre of the project is evolving currently but everything to be concerned about lives in the Web project the other projects that exist will be going away.  In the Web folder the application is in an organized mess but the folders to be concerned about are the  API folder where the WEB.API endpoints live and the Modules folder is where the MVC functionality lives.  This needs to be evolved as you see need.

### Third party Integration
Akamai and Wirecast are the two major players in this department, and a major way Tilted Globe will be monetizing their operation.  Wirecast is the software used by prodcures to encode events and Akamai is what is being used to broadcast those out to all viewers.  The viewers are able to see live/ondemand events via a simple embeded Akamai player(AMP) on the TiltedGlobe website.  There has been some preliminary work to integrate both but this is a work in progress currently I am awaiting feedback from both companies.  Download the wirecast software from here www.telestream.net - key documentation to take a look at for this integration is the Wirecast Destination Protocol document in dropbox.  From the Akamai side the key pieces of documentation to look at are:

Media Streaming API (https://developer.akamai.com/api/luna/config-media-live/overview.html) - this will be utilized by the application to create a stream and generate the proper link for Wirecast

Adaptive Media Player (http://projects.mediadev.edgesuite.net/customers/docs/AMP%20Standard%20guide%20v2.pdf) - this is the player that will be used to embed into the application for viewers to visit - to accompany this also check out this sample  http://projects.mediadev.edgesuite.net/customers/akamai/mdt-html5-core/standard/4.28.0.0005/

Getting access to the luna control panel will probably be needed if you get in depth with Akamai


### Get Developing

1. Clone repo from bitbucket https://bitbucket.org/surgeforward/tilted_globe
2. Open TiltedGlobe\TiltedGlobe.sln 
3. Open VS Package Manager Console, click Restore to install NuGet packages
4. Install Node.js latest, if necessary.
5. Install bower.js, if necessary.
6. Open a command prompt at \tilted_globe\TiltedGlobe\TiltedGlobe
7. Run bower install

TODO:

* Frontend packaging - currently there is nothing setup merely using bower and including those links on the master pages options
* IOC - not setup
* Testing - front or backend
* CSS - no preprocessing being done
* Server validation
* Logging
* Security
* Moving S3 files from a staging to approved directory server side
* Global Admin Module
* Stripe Integration
* complete wirecast/akamai integration