# FunctionsServiceBusWriter
Sample functions demonstrating the difference in service bus queue write behavior between in-pro and out-of-proc.

Both projects have an HTTP Endpoint(`/api/WriteToServiceBus`) which returns an instance of `ServiceBusMessage` (from `Azure.Messaging.ServiceBus` package)

The output from in-proc app is correctly persisting the meta properties (like Subject, MessageId) while the OOP app writes the JSON version of entier payload (including the meta property values we defined) as the body of the message.
See screenshot below.

Message written by in-process app(as seen in azure portal service bus explorer)


Message written by out-of-process app(as seen in azure portal service bus explorer)


