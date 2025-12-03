<template>
<v-app-bar :elevation="2">
  <template v-slot:prepend>
    <v-tooltip
        :open-on-hover="false"
        :persistent="false"
        location="bottom"
        open-on-click>
      <template v-slot:activator="{ props }">
        <v-app-bar-nav-icon v-bind="props"></v-app-bar-nav-icon>
      </template>
      <span>TODO: expandable menu</span>
    </v-tooltip>
  </template>

  <v-app-bar-title><RouterLink to="/">Emege</RouterLink></v-app-bar-title>
  
  <template v-slot:append>
    <!-- TODO: route to sign-in page if not signed in -->
    <v-btn icon="mdi-account" to="/profile" :active="false" v-tooltip="'Profile / Sign in'"></v-btn>

    <!-- TODO: implement user search -->
    <v-btn icon="mdi-magnify" v-tooltip="searchUsersTooltip"></v-btn>
  </template>
</v-app-bar>
</template>

<script setup>
  import { RouterLink } from 'vue-router';

  // tooltip definition
  const searchUsersTooltip = {
    text: "TODO: search users",
    location: "bottom",
    persistent: false,
    openOnClick: true,
    openOnHover: false
  };
</script>