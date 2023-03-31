# Lab3_UMS_Consumer
Simple consumer of the notification queue that continuously listens to events being published to said queue. Once event is triggered, notification is saved to a separate NotificationCenter database. Changes to the db are immediate (IHosted service perk) but is reflected upon get request.
