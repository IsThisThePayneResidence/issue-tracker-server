# Issue Tracker [Server/Daemon]
This is a sample issue tracker application that communicates through RabbitMQ
The app is written in C# and uses MongoDB as the storage

## Naming

### RabbitMQ 

RabbitMQ names should match the following template: [rabbitmq-entity].[domain-entity].[application].[unique-name]
They mush contain 4 blocks of data separated with **'.'**

#### RabbitMQ Entities
- Queue names should start with **q.**
- Exchange names should start with **e.**
- Routing keys should start with **r.**

#### Domain entities
- RabbitMQ entities that have something to do with __issues__ should have __.i.__ in their name
- RabbitMQ entities that have something to do with __statuses__ should have __.s.__ in their name
- RabbitMQ entities that have something to do with __users__ should have __.u.__ in their name

#### Application
Should contain name of the application that owns the RabbitMQ entity (queue or exchange)

#### Unique Name
This is block is not particularly defined. There could be anything that helps you understand what is this queue/exchange for
for instance `e.i.it-daemon.command` and `e.i.it-daemon.query`

## Routing
Considering former naming rules, we can come up with some routing rules for RabbitMQ

![RabbitMQ Routing Map](https://pp.vk.me/c631123/v631123043/44d07/X-HH03SVYKo.jpg "RabbitMQ Routing Map")

## Methods
To remotely call a daemon procedure client needs to send a message with `reply-to` and `correlation-id` to `e.all.all.forward` with appropriate routing key (depends on what entity you want to alter or query) and JSON body in format

```json
{
  "method": ${methodName},
  "data": ${objectFields}
}
```

Where `${methodName}` must be replaced with `get`, `create`, `update` or `delete`

And `${objectFields}` mush be replaced with the fields daemon will need to execute procedure

**For example**

- If you need to create a user
Header:
  * Reply To: q.u.client.reply
  * Correlation Id: 1488
Body:
```json
{
  "method": "create",
  "data": {
    "username": "jo123",
    "firstName": "John",
    "lastName": "Doe",
    "password": "j0j1be@7s",
    "role": "Admin"
  }
}
```
*Note: we do not explicitly set the __id__ - daemon will take care of it himself*

- If you later need to alter this user, for example, change it's password
Header:
  * Reply To: q.u.client.reply
  * Correlation Id: 8814
Body:
```json
{
  "method": "update",
  "data": {
    "id": 12,
    "password": "OreWaOchinchinGaDaisukiNandayo"
  }
}
```
*Note: The user id can be gathered from `e.u.daemon.feed` or throught `get` request*



