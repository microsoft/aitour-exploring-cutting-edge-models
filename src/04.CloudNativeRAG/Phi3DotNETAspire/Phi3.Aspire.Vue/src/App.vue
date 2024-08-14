<script setup lang="ts">
</script>

<template>
  <div id="chat-container" style="width:100%">
    <div id="chat-header" style="width:100%">Phi-3 Q&A</div>
    <div id="messages">
      <div v-for="(message, index) in messages" :key="index" :class="message.type">
        {{ message.text }}
      </div>
    </div>
    <div id="input-area">
      <input type="text" v-model="newMessage" id="message-input" placeholder="Type a message..." @keyup.enter="sendMessage">
      <button id="send" @click="sendMessage"><i class="fas fa-paper-plane"></i></button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  data() {
    return {
      newMessage: '',
      prompt: '',
      messages: []
    };
  },
  methods: {
    sendMessage() {
      if (this.newMessage.trim() !== '') {
        // Add the new message to the messages array as a sender message
        const object = { Prompt: this.newMessage };
        this.messages.push({ text: this.newMessage, type: 'sender' });
        this.prompt = JSON.stringify(object);
        // Clear the input field
        this.newMessage = '';

        // alert(this.prompt);
        // Simulate a reply after a short delay
        // setTimeout(() => {
        //  this.messages.push({ text: 'This is an automated reply.', type: 'receiver' });
        // }, 500);
        
        // 使用fetch发送POST请求到/api/chat，传送message
        fetch('api/chat', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: this.prompt,
        })
        .then(response => {
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
          // console.log(response['gen_text']);
          return response.json();
        })
        .then(data => {
          console.log('Message sent:', data);
          // 假设API返回的回复消息在data.message中
          this.messages.push({ text: data.gen_text, type: 'receiver' });
        })
        .catch(error => {
          console.error('Error sending message:', error);
          // 处理错误情况，例如显示错误消息
        });
      }
    }
  }
});
</script>

<style scoped>
/* body, html {
    margin: 0;
    padding: 0;
    height: 100%;
    width: 100%;
    font-family: Arial, sans-serif;
}

#app {
    height: 100%;
    width: 95%;
    display: flex;
    flex-direction: column;
} */

#chat-container {
    height: 100vh;
    width: 100%;
    display: flex;
    flex-direction: column;
}

#chat-header {
    padding: 10px;
    background-color: #0084ff;
    color: white;
    text-align: center;
    width: 100%;
}

#messages {
    flex-grow: 1;
    overflow-y: auto;
}

.message {
    margin-bottom: 10px;
    padding: 10px;
    border-radius: 20px;
    max-width: 1500px;
}

.sent {
    background-color: #0084ff;
    color: white;
    margin-left: auto;
}

.received {
    background-color: #f1f0f0;
}

#input-area {
    display: flex;
    padding: 10px;
    background-color: white;
    border-top: 1px solid #ccc;
}

#message-input {
    flex-grow: 1;
    border: 1px solid #ccc;
    border-radius: 20px;
    padding: 10px;
    margin-right: 10px;
}

#send {
    border: none;
    background-color: #0084ff;
    color: white;
    padding: 10px 20px;
    border-radius: 20px;
    cursor: pointer;
}

.sender {
    background-color: #DCF8C6; /* 浅绿色背景 */
    color: black; /* 文字颜色 */
    padding: 8px 10px; /* 内边距 */
    margin: 4px 10px 4px auto; /* 外边距，自动左边距使其右对齐 */
    border-radius: 10px; /* 边框圆角 */
    max-width: 60%; /* 最大宽度 */
    box-sizing: border-box; /* 盒模型 */
    word-wrap: break-word; /* 在长单词或URL达到容器边界时换行 */
    word-break: break-word; /* 在必要时在单词内部进行换行 */
}

.receiver {
    background-color: #ECECEC; /* 浅灰色背景 */
    color: black; /* 文字颜色 */
    padding: 8px 10px; /* 内边距 */
    margin: 4px auto 4px 10px; /* 外边距，自动右边距使其左对齐 */
    border-radius: 10px; /* 边框圆角 */
    max-width: 60%; /* 最大宽度 */
    box-sizing: border-box; /* 盒模型 */
    word-wrap: break-word; /* 在长单词或URL达到容器边界时换行 */
    word-break: break-word; /* 在必要时在单词内部进行换行 */
}
</style>