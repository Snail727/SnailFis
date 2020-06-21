'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
  // NODE_ENV: '"http://localhost:63834/snailFis_api"',
  NODE_ENV: '"development"',
  API_ROOT:'"http://localhost:63834/snailFis_api"'
})