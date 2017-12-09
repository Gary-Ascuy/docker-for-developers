const express = require('express')
const app = express()

function log(page, method, message) {
  console.log(new Date(), `[${page}]`, `[${method}]`, message)
}

// entrypoints
app.get('/', (req, res) => {
  const host = process.env.HOSTNAME || 'Generic'
  log('HOME', 'GET', `${host} Hello World - From NodeJS!`)
  res.send(`
    <h1>
      <center>${host} ~ Hello World - From NodeJS ${process.version}</center>
    <h1>
  `)
})

app.get('/about', (req, res) => {
  log('ABOUT', 'GET', 'Docker For Developers!')
  res.send('Docker For Developers!')
})

// start
const port = process.env.APP_PORT || 3666
app.listen(port, () => {
  console.log(`Starting NodeJS App - listening on port ${port}!`)
})
