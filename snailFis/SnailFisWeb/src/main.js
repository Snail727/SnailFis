// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import BaseComponent from '@/components'
import Elementui from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css';


Vue.use(Elementui)
Vue.config.productionTip = false //消息提示的环境配置，设置为开发环境或生产环境

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>',
})

Vue.use(BaseComponent);
