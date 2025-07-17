pipeline {
    agent any

    environment {
        CHROME_VERSION = '127.0.6533.73'
        CHROMEDRIVER_VERSION = '127.0.6533.72'
        CHROME_INSTALL_PATH = 'C:\\Program Files\\Google\\Chrome\\Application'
        CHROMEDRIVER_PATH = '"C:\\Program Files\\Google\\Chrome\\Application\\chromedriver.exe"'
    }

    stages {
        stage('Checkout code') {
            steps {
                // Checkout code from GitHub and specify the branch
                git branch: 'main', url: 'https://github.com/???/SeleniumIDE.git'
            }
        }

        stage('Set up .NET Core') {
            steps {
                bat '''
                echo Installing .NET SDK 6.0
                choco install dotnet-sdk -y --version=6.0.100
                '''
            }
        }

         stage('Uninstall Current Chrome') {
            steps {
                bat '''
                echo Uninstalling current Google Chrome
                choco uninstall googlechrome -y
                '''
            }
        }
        
        stage('Download and Install ChromeDriver') {
            steps {
                bat '''
                echo Downloading ChromeDriver version %CHROMEDRIVER_VERSION%
                powershell -command "Invoke-WebRequest -Uri https://chromedriver.storage.googleapis.com/%CHROMEDRIVER_VERSION%/chromedriver_win32.zip -OutFile chromedriver.zip -UseBasicParsing"
                powershell -command "Expand-Archive -Path chromedriver.zip -DestinationPath ."
                powershell -command "Move-Item -Path .\\chromedriver.exe -Destination '%CHROME_INSTALL_PATH%\\chromedriver.exe' -Force"
                '''
            }
        }

         stage('Restore dependencies') {
            steps {
                // Restore dependencies using the solution file
                bat 'dotnet restore SeleniumBasicExercise.sln'
            }
        }


        stage('Build') {
            steps {
                // Build the project using the solution file
                bat 'dotnet build SeleniumBasicExercise.sln --no-restore'
            }
        }

        stage('Run TestProject1 tests') {
            steps {
                bat '''
                echo "Running TestProject1 tests"
                dotnet test TestProject1/TestProject1.csproj --verbosity normal
                '''
            }
        }

        stage('Run TestProject2 tests') {
            steps {
                bat '''
                echo "Running TestProject2 tests"
                dotnet test TestProject2/TestProject2.csproj --verbosity normal
                '''
            }
        }

        stage('Run TestProject3 tests') {
            steps {
                bat '''
                echo "Running TestProject3 tests"
                dotnet test TestProject3/TestProject3.csproj --verbosity normal
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/TestResults/*.trx', allowEmptyArchive: true
            junit '**/TestResults/*.trx'
        }
    }
}