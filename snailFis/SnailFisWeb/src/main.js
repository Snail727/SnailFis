// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store/store.js'
import storeMapping from './store/storeMapping.js'
import Directives from './Directives.js'
import BaseComponent from '@/components'
import Elementui from 'element-ui'
import PrototypePack from "@/scripts/PrototypePack.js"
import 'element-ui/lib/theme-chalk/index.css';


Vue.use(Elementui)
PrototypePack.initMixins(Vue);
Vue.config.productionTip = false //消息提示的环境配置，设置为开发环境或生产环境
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>',
  computed:{
    count(){
      this.$store.state.count;
    }
  }
})

Vue.use(BaseComponent);
storeMapping.initMixins(Vue);
Directives.initMixins(Vue);
