package main

import (
		"time"
    "fmt"
    "net/http"
)

func log(page, method, message string) {
	fmt.Printf("%s [%s] [%s] ~ %s\n", time.Now(), page, method, message)
}

func handler(w http.ResponseWriter, r *http.Request) {
		log("HOME", "GET", "Hi there, I love Go-Lang")
		fmt.Fprintf(w, "<h1><center>Hi there, I love Go-Lang ~ %s!</center></h1>", r.URL.Path[1:])
}

func main() {
    http.HandleFunc("/", handler)
		fmt.Println("Starting Go Lang App - listening on port 8666!")
    http.ListenAndServe(":8666", nil)
}
