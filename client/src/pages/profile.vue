<!-- TODO: image gallery, adding images, creating collection, user data and stats -->
<template>
    <h1>Hi I'm Greg</h1>
    <p>My user endpoint yields: {{ userInfo }}</p>
</template>

<script lang="ts" setup>
import axios from 'axios';

  const userInfo = ref("wait for it!");
  let userName = "greg";
  axios.get(`/api/users/${userName}`)
    .then(response => {
      console.info(response.data)
      userInfo.value = response.data;
    })
    .catch(err => {
      console.error("err:", err);
    });

</script>
