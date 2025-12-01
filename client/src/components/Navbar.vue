<template>
<v-app-bar :elevation="2">
  <template v-slot:prepend>
    <v-app-bar-nav-icon></v-app-bar-nav-icon>
  </template>

  <v-app-bar-title><RouterLink to="/">Emege</RouterLink></v-app-bar-title>
  
  <template v-slot:append>
    <!-- TODO: if not LOGGED_IN "Log in" else "Profile"   -->
    <RouterLink to="/profile">Profile</RouterLink>

    <!-- TODO: implement user search -->
    <v-btn icon="mdi-magnify"></v-btn>
  </template>
</v-app-bar>
</template>

<script setup>
import { RouterLink } from 'vue-router';

</script>