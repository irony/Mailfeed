Mailfeed
========

_An example application combining SignalR and MailGun_

This application is a proof of concept of how to create a live updated feed of incoming mail. The incoming mail are pushed
from Mailgun to this MVC3 application and are feeded to a SignalR event hub which syncs a feed of mail via WebSockets to the
client with the library SignalR.

